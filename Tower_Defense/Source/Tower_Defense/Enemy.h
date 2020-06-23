// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "Enemy.generated.h"
#include "Components/SphereComponent.h"
UCLASS()
class TOWER_DEFENSE_API AEnemy : public ACharacter
{
	GENERATED_BODY()
	
	// How fast he is  
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = EnemyProperties)
	float Speed;  
	
	// The hitpoints the monster has  
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = EnemyProperties)
	float HitPoints;  
	
	// Experience gained for defeating  
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = EnemyProperties)
	int32 Experience;  
	
	// Blueprint of the type of item dropped by the monster  
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = EnemyProperties)
	UClass* BPLoot;  
	
	// The amount of damage attacks do  
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = EnemyProperties)
	float BaseAttackDamage;  
	
	// Amount of time the monster needs to rest in seconds  
	// between attacking
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = EnemyProperties)
	float AttackTimeout;  
	
	// Time since monster's last strike, readable in blueprints  
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = EnemyProperties)
	float TimeSinceLastStrike;  
	
	// Range for his sight  
	UPROPERTY(VisibleDefaultsOnly, BlueprintReadOnly, Category =    Collision)  
	USphereComponent* SightSphere;

	// Range for his attack. Visualizes as a sphere in editor,  
	UPROPERTY(VisibleDefaultsOnly, BlueprintReadOnly, Category =    Collision)  
	USphereComponent* AttackRangeSphere;

public:
	// Sets default values for this character's properties
	AEnemy();

protected:
	AEnemy(const FObjectInitializer & PCIP);
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

};
