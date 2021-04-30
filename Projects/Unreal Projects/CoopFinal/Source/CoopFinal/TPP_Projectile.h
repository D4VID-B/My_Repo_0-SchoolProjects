// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "TPP_Projectile.generated.h"

UCLASS()
class COOPFINAL_API ATPP_Projectile : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ATPP_Projectile();

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Components")
		class USphereComponent* SphereComp;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Components")
		class UStaticMeshComponent* StaticMesh;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Components")
		class UProjectileMovementComponent* ProjectileMovementComp;

	UPROPERTY(EditAnywhere, Category = "FX")
		class UParticleSystem* Explosion;

	UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = "Damage")
		TSubclassOf<class UDamageType> DamageType;

	UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = "Damage")
		float mDamage;

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	virtual void Destroyed() override;

protected:

	UFUNCTION(Category = "Projectile")
		void OnProjectileImpact(UPrimitiveComponent* HitComp, AActor* OtherActor, UPrimitiveComponent* OtherComp, FVector NormalImpulse, const FHitResult& Hit);

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
