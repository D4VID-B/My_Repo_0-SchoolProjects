// Copyright Epic Games, Inc. All Rights Reserved.

#include "CoopFinalCharacter.h"
#include "HeadMountedDisplayFunctionLibrary.h"
#include "Camera/CameraComponent.h"
#include "Components/CapsuleComponent.h"
#include "Components/InputComponent.h"
#include "GameFramework/CharacterMovementComponent.h"
#include "GameFramework/Controller.h"
#include "GameFramework/SpringArmComponent.h"
#include "Net/UnrealNetwork.h"
#include "Engine/Engine.h"
#include "TPP_Projectile.h"

//////////////////////////////////////////////////////////////////////////
// ACoopFinalCharacter

ACoopFinalCharacter::ACoopFinalCharacter()
{
	// Set size for collision capsule
	GetCapsuleComponent()->InitCapsuleSize(42.f, 96.0f);

	// set our turn rates for input
	BaseTurnRate = 45.f;
	BaseLookUpRate = 45.f;

	// Don't rotate when the controller rotates. Let that just affect the camera.
	bUseControllerRotationPitch = false;
	bUseControllerRotationYaw = false;
	bUseControllerRotationRoll = false;

	// Configure character movement
	GetCharacterMovement()->bOrientRotationToMovement = true; // Character moves in the direction of input...	
	GetCharacterMovement()->RotationRate = FRotator(0.0f, 540.0f, 0.0f); // ...at this rotation rate
	GetCharacterMovement()->JumpZVelocity = 600.f;
	GetCharacterMovement()->AirControl = 0.2f;

	// Create a camera boom (pulls in towards the player if there is a collision)
	CameraBoom = CreateDefaultSubobject<USpringArmComponent>(TEXT("CameraBoom"));
	CameraBoom->SetupAttachment(RootComponent);
	CameraBoom->TargetArmLength = 300.0f; // The camera follows at this distance behind the character	
	CameraBoom->bUsePawnControlRotation = true; // Rotate the arm based on the controller

	// Create a follow camera
	FollowCamera = CreateDefaultSubobject<UCameraComponent>(TEXT("FollowCamera"));
	FollowCamera->SetupAttachment(CameraBoom, USpringArmComponent::SocketName); // Attach the camera to the end of the boom and let the boom adjust to match the controller orientation
	FollowCamera->bUsePawnControlRotation = false; // Camera does not rotate relative to arm

	mMAX_HEALTH = 100.0f;

	mCurrentHealth = mMAX_HEALTH;

	FireballProjectile = ATPP_Projectile::StaticClass();

	RoF = 0.25f;

	isFiring = false;
}

//////////////////////////////////////////////////////////////////////////
// Input

void ACoopFinalCharacter::SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent)
{
	// Set up gameplay key bindings
	check(PlayerInputComponent);
	PlayerInputComponent->BindAction("Jump", IE_Pressed, this, &ACharacter::Jump);
	PlayerInputComponent->BindAction("Jump", IE_Released, this, &ACharacter::StopJumping);

	PlayerInputComponent->BindAxis("MoveForward", this, &ACoopFinalCharacter::MoveForward);
	PlayerInputComponent->BindAxis("MoveRight", this, &ACoopFinalCharacter::MoveRight);

	// We have 2 versions of the rotation bindings to handle different kinds of devices differently
	// "turn" handles devices that provide an absolute delta, such as a mouse.
	// "turnrate" is for devices that we choose to treat as a rate of change, such as an analog joystick
	PlayerInputComponent->BindAxis("Turn", this, &APawn::AddControllerYawInput);
	PlayerInputComponent->BindAxis("TurnRate", this, &ACoopFinalCharacter::TurnAtRate);
	PlayerInputComponent->BindAxis("LookUp", this, &APawn::AddControllerPitchInput);
	PlayerInputComponent->BindAxis("LookUpRate", this, &ACoopFinalCharacter::LookUpAtRate);

	PlayerInputComponent->BindAction("Fire", IE_Pressed, this, &ACoopFinalCharacter::StartFire);
}


void ACoopFinalCharacter::TurnAtRate(float Rate)
{
	// calculate delta for this frame from the rate information
	AddControllerYawInput(Rate * BaseTurnRate * GetWorld()->GetDeltaSeconds());
}

void ACoopFinalCharacter::LookUpAtRate(float Rate)
{
	// calculate delta for this frame from the rate information
	AddControllerPitchInput(Rate * BaseLookUpRate * GetWorld()->GetDeltaSeconds());
}

void ACoopFinalCharacter::MoveForward(float Value)
{
	if ((Controller != nullptr) && (Value != 0.0f))
	{
		// find out which way is forward
		const FRotator Rotation = Controller->GetControlRotation();
		const FRotator YawRotation(0, Rotation.Yaw, 0);

		// get forward vector
		const FVector Direction = FRotationMatrix(YawRotation).GetUnitAxis(EAxis::X);
		AddMovementInput(Direction, Value);
	}
}

void ACoopFinalCharacter::MoveRight(float Value)
{
	if ( (Controller != nullptr) && (Value != 0.0f) )
	{
		// find out which way is right
		const FRotator Rotation = Controller->GetControlRotation();
		const FRotator YawRotation(0, Rotation.Yaw, 0);
	
		// get right vector 
		const FVector Direction = FRotationMatrix(YawRotation).GetUnitAxis(EAxis::Y);
		// add movement in that direction
		AddMovementInput(Direction, Value);
	}
}


//////////////////////////////////////////////////////////////////////////
// Shooting

void ACoopFinalCharacter::StartFire()
{
	if (!isFiring)
	{
		isFiring = true;

		UWorld* World = GetWorld();

		World->GetTimerManager().SetTimer(ShootTimer, this, &ACoopFinalCharacter::StopFire, RoF, false);

		HandleFire();
	}
}

void ACoopFinalCharacter::StopFire()
{
	isFiring = false;
}

void ACoopFinalCharacter::HandleFire_Implementation()
{
	FVector spawnLoc = GetActorLocation() + (GetControlRotation().Vector() * 100.0f) + (GetActorUpVector() * 50.0f);

	FRotator spawnRot = GetControlRotation();

	FActorSpawnParameters spawnParams;

	spawnParams.Instigator = GetInstigator();

	spawnParams.Owner = this;

	ATPP_Projectile* projectile = GetWorld()->SpawnActor<ATPP_Projectile>(spawnLoc, spawnRot, spawnParams);
}


//////////////////////////////////////////////////////////////////////////
// Networking

void ACoopFinalCharacter::GetLifetimeReplicatedProps(TArray <FLifetimeProperty>& OutLifetimeProps) const
{
	Super::GetLifetimeReplicatedProps(OutLifetimeProps);


	DOREPLIFETIME(ACoopFinalCharacter, mCurrentHealth);
}

void ACoopFinalCharacter::OnRep_CurrentHealth()
{
	UpdateHealth();
}

void ACoopFinalCharacter::UpdateHealth()
{
	if (IsLocallyControlled())
	{
		FString healthUpdateMsg = FString::Printf(TEXT("Health ==> %f"), mCurrentHealth);
		GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Yellow, healthUpdateMsg);

		if (mCurrentHealth <= 0)
		{
			FString deathMsg = FString::Printf(TEXT("YOU DIED."));
			GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Red, deathMsg);
		}
	}

	if (GetLocalRole() == ROLE_Authority)
	{
		FString healthMessage = FString::Printf(TEXT("%s now has %f health remaining."), *GetFName().ToString(), mCurrentHealth);
		GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Blue, healthMessage);
	}

	//Common functionality goes here:

	//Do something when a player dies
}

void ACoopFinalCharacter::setCurrentHP(float value)
{
	if (GetLocalRole() == ROLE_Authority)
	{
		mCurrentHealth = FMath::Clamp(value, 0.0f, mMAX_HEALTH);

		UpdateHealth();
	}
}

float ACoopFinalCharacter::TakeDamage(float amount, struct FDamageEvent const& DamageEvent, AController* EventInstigator, AActor* DamageCause)
{
	float damage = mCurrentHealth - amount;

	setCurrentHP(damage);

	return damage;
}