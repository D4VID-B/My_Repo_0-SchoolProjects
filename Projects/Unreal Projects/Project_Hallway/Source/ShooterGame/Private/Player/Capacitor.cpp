// Project licenced under a licence that will be included in the future

#include "ShooterGame.h"
#include "Player/Capacitor.h"

// Sets default values
ACapacitor::ACapacitor()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	currentCharge = MAX_CHARGE;


}

// Called when the game starts or when spawned
void ACapacitor::BeginPlay()
{
	//Super::BeginPlay();
	
}

// Called every frame
void ACapacitor::Tick(float DeltaTime)
{
	//Super::Tick(DeltaTime);

}

void ACapacitor::AddCharge(int amount)
{
	currentCharge += amount;

	if (currentCharge > MAX_CHARGE)
	{
		currentCharge = MAX_CHARGE;
	}

}

float ACapacitor::ConsumeCharge()
{
	int charge = currentCharge;

	currentCharge = 0;

	return charge * consumeModifier;
}