// Project licenced under a licence that will be included in the future

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Capacitor.generated.h"

UCLASS()
class SHOOTERGAME_API ACapacitor : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ACapacitor();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

public:

	int GetCurrentCharge() { return currentCharge; };

	void SpendCharge(int amount) { currentCharge -= amount; };

	void AddCharge(int amount);

	float ConsumeCharge();

protected:

	const int MAX_CHARGE = 100;

	int currentCharge;

	float consumeModifier = .25;

};