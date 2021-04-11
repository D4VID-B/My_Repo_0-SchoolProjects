// Project licenced under a licence that will be included in the future

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "EnergyWeaponInstantBase.generated.h"

UENUM(BlueprintType)
enum WeaponType
{
	Shotgun UMETA(DisplayName = "Shotgun"),
	Railgun UMETA(DisplayName = "Railgun"),
	//Grenade UMETA(DisplayName = "Grenade"),

};

UCLASS(Blueprintable)
class SHOOTERGAME_API AEnergyWeaponInstantBase : public AActor
{
	GENERATED_BODY()
	
	UFUNCTION(BlueprintCallable, Category = "Energy Weapon")
		class AShooterCharacter* GetPawnOwner() const;

	UFUNCTION(BlueprintCallable, Category = "Energy Weapon")
		void SetPawnOwner(AShooterCharacter* newOwner);

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Sets default values for this actor's properties
	//This will always set the weapon type to the first value
	AEnergyWeaponInstantBase();

	//This is the prefered constructor, since it allows us to specify what kind of weapon this is
	AEnergyWeaponInstantBase(WeaponType type);

	UFUNCTION(BlueprintCallable)
		bool UseAmmo();

	UFUNCTION()
		WeaponType GetWeaponType() { return mWeaponType; };

	FHitResult TraceShot(const FVector& TraceFrom, const FVector& TraceTo) const;


protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	UPROPERTY(BlueprintReadWrite/*Transient, ReplicatedUsing = OnRep_MyPawn*/)
		class AShooterCharacter* MyPawn;

	//What kind of weapon this actually is:
	UPROPERTY(BlueprintReadWrite, Category = EnergyWeapon)
		TEnumAsByte<WeaponType> mWeaponType;

	UPROPERTY(BlueprintReadWrite, Category = EnergyWeapon)
		int mShotCost;

	UPROPERTY(BlueprintReadWrite, Category = EnergyWeapon)
		float mRateOfFire;

	UPROPERTY(BlueprintReadWrite, Category = EnergyWeapon)
		float mModeSwitchDuration;

	UPROPERTY(BlueprintReadWrite, Category = EnergyWeapon)
		bool isFiring;
};
