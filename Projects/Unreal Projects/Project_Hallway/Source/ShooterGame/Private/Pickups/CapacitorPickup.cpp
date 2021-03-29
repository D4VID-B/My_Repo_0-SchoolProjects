// Project licenced under a licence that will be included in the future

#include "ShooterGame.h"
#include "Pickups/CapacitorPickup.h"
#include "Particles/ParticleSystemComponent.h"


void ACapacitorPickup::NotifyActorBeginOverlap(class AActor* Other)
{
	//Super::NotifyActorBeginOverlap(Other);
	PickupOnTouch(Cast<AShooterCharacter>(Other));
}

bool ACapacitorPickup::CanBePickedUp(class AShooterCharacter* TestPawn) const
{
	return TestPawn && TestPawn->IsAlive();
}

void ACapacitorPickup::PickupOnTouch(class AShooterCharacter* Pawn)
{
	if (bIsActive && Pawn && Pawn->IsAlive() && !IsPendingKill())
	{
		if (CanBePickedUp(Pawn))
		{
			GivePickupTo(Pawn);
			PickedUpBy = Pawn;

			if (!IsPendingKill())
			{
				bIsActive = false;
				OnPickedUp();
			}
		}
	}
}

void ACapacitorPickup::OnPickedUp()
{

	if (PickupSound && PickedUpBy)
	{
		UGameplayStatics::SpawnSoundAttached(PickupSound, PickedUpBy->GetRootComponent());
	}

	OnPickedUpEvent();
}

void ACapacitorPickup::GivePickupTo(class AShooterCharacter* Pawn)
{
	Pawn->addCapacitor();
}

void AShooterPickup::GetLifetimeReplicatedProps(TArray< FLifetimeProperty >& OutLifetimeProps) const
{
	Super::GetLifetimeReplicatedProps(OutLifetimeProps);

	DOREPLIFETIME(ACapacitorPickup, bIsActive);
	DOREPLIFETIME(ACapacitorPickup, PickedUpBy);
}