// Project licenced under a licence that will be included in the future

#pragma once

#include "CoreMinimal.h"
#include "Pickups/ShooterPickup.h"
#include "CapacitorPickup.generated.h"

/**
 * 
 */
UCLASS()
class SHOOTERGAME_API ACapacitorPickup : public AActor
{
	GENERATED_BODY()
	
	virtual void NotifyActorBeginOverlap(class AActor* Other) override;

protected:

	UPROPERTY(EditDefaultsOnly, Category = Effects)
		UParticleSystem* ActiveFX;

	UPROPERTY(EditDefaultsOnly, Category = Effects)
		USoundCue* PickupSound;

	UPROPERTY(Transient, Replicated/*ReplicatedUsing = OnRep_IsActive*/)
		uint32 bIsActive : 1;

	UPROPERTY(Transient, Replicated)
		AShooterCharacter* PickedUpBy;

	void GivePickupTo(class AShooterCharacter* Pawn);

	void PickupOnTouch(class AShooterCharacter* Pawn);

	virtual void OnPickedUp();

	virtual bool CanBePickedUp(class AShooterCharacter* TestPawn) const;

	UFUNCTION(BlueprintImplementableEvent)
		void OnPickedUpEvent();

};
