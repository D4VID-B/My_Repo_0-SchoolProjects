// Project licenced under a licence that will be included in the future

#include "ShooterGame.h"
#include "Weapons/EnergyWeaponInstantBase.h"

// Sets default values
AEnergyWeaponInstantBase::AEnergyWeaponInstantBase()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	mWeaponType = WeaponType::Shotgun;
	mShotCost = 6;
	mAltShotCost = 7;
	mRateOfFire = 1;
	mModeSwitchDuration = .5;

}

AEnergyWeaponInstantBase::AEnergyWeaponInstantBase(WeaponType type)
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	mWeaponType = type;

	//Set the base stats according to the weapon type
	switch (mWeaponType)
	{
	case WeaponType::Shotgun:
		mShotCost = 6;
		mAltShotCost = 7;
		mRateOfFire = 1;
		mModeSwitchDuration = .5;
		break;

	case WeaponType::Railgun:
		mShotCost = 20;
		mAltShotCost = 20;
		mRateOfFire = 1;
		mModeSwitchDuration = 2;
		break;
	}

}

// Called when the game starts or when spawned
void AEnergyWeaponInstantBase::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AEnergyWeaponInstantBase::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

bool AEnergyWeaponInstantBase::UseAmmo(bool inAltFire)
{
	bool status;

	if (inAltFire)
	{
		status = MyPawn->spendCapacitorEnergy(mAltShotCost);
	}
	else
	{
		status = MyPawn->spendCapacitorEnergy(mShotCost);
	}

	return status;
}

class AShooterCharacter* AEnergyWeaponInstantBase::GetPawnOwner() const
{
	return MyPawn;
}

void AEnergyWeaponInstantBase::SetPawnOwner(AShooterCharacter* newOwner)
{
	MyPawn = newOwner;
}

void AEnergyWeaponInstantBase::SetShotCost(int newCost)
{
	mShotCost = newCost;
}

void AEnergyWeaponInstantBase::SetAltShotCost(int newCost)
{
	mAltShotCost = newCost;
}