// Fill out your copyright notice in the Description page of Project Settings.


#include "TPP_Projectile.h"
#include "Components/SphereComponent.h"
#include "Components/StaticMeshComponent.h"
#include "GameFramework/ProjectileMovementComponent.h"
#include "GameFramework/DamageType.h"
#include "Particles/ParticleSystem.h"
#include "Kismet/GameplayStatics.h"
#include "UObject/ConstructorHelpers.h"

// Sets default values
ATPP_Projectile::ATPP_Projectile()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	bReplicates = true;

	SphereComp = CreateDefaultSubobject<USphereComponent>(TEXT("RootComponent"));
	SphereComp->InitSphereRadius(37.5f);
	SphereComp->SetCollisionProfileName(TEXT("BlockAllDynamic"));
	RootComponent = SphereComp;

	if (GetLocalRole() == ROLE_Authority)
	{
		SphereComp->OnComponentHit.AddDynamic(this, &ATPP_Projectile::OnProjectileImpact);
	}

	static ConstructorHelpers::FObjectFinder<UStaticMesh> DefaultMesh(TEXT("/Game/StarterContent/Shapes/Shape_Sphere.Shape_Sphere"));
	StaticMesh = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Mesh"));
	StaticMesh->SetupAttachment(RootComponent);

	if (DefaultMesh.Succeeded())
	{
		StaticMesh->SetStaticMesh(DefaultMesh.Object);
		StaticMesh->SetRelativeLocation(FVector(0.0f, 0.0f, -37.5f));
		StaticMesh->SetRelativeScale3D(FVector(0.75f, 0.75f, 0.75f));
	}

	static ConstructorHelpers::FObjectFinder<UParticleSystem> DefaultExplosionEffect(TEXT("/Game/StarterContent/Particles/P_Explosion.P_Explosion"));
	
	if (DefaultExplosionEffect.Succeeded())
	{
		Explosion = DefaultExplosionEffect.Object;
	}

	ProjectileMovementComp = CreateDefaultSubobject<UProjectileMovementComponent>(TEXT("ProjectileMovement"));
	ProjectileMovementComp->SetUpdatedComponent(SphereComp);
	ProjectileMovementComp->InitialSpeed = 1500.0f;
	ProjectileMovementComp->MaxSpeed = 2000.0f;
	ProjectileMovementComp->bRotationFollowsVelocity = true;
	ProjectileMovementComp->ProjectileGravityScale = 0.0f;

	DamageType = UDamageType::StaticClass();
	mDamage = 10.0f;
}

// Called when the game starts or when spawned
void ATPP_Projectile::BeginPlay()
{
	Super::BeginPlay();
	
}

void ATPP_Projectile::Destroyed()
{
	FVector spawnLoc = GetActorLocation();

	UGameplayStatics::SpawnEmitterAtLocation(this, Explosion, spawnLoc, FRotator::ZeroRotator, true, EPSCPoolMethod::AutoRelease);
}

// Called every frame
void ATPP_Projectile::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ATPP_Projectile::OnProjectileImpact(UPrimitiveComponent* HitComp, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit)
{
	if (OtherActor)
	{
		UGameplayStatics::ApplyPointDamage(OtherActor, mDamage, NormalImpulse, Hit, GetInstigator()->Controller, this, DamageType);
	}

	Destroy();
}