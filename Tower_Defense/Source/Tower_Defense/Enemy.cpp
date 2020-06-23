// Fill out your copyright notice in the Description page of Project Settings.


#include "Enemy.h"

// Sets default values
AEnemy::AEnemy(const class FObjectInitializer& PCIP) : Super(PCIP)
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	Speed = 20;  
	HitPoints = 20; 
	Experience = 0;  
	BPLoot = NULL;  
	BaseAttackDamage = 1;  
	AttackTimeout = 1.5f;  
	TimeSinceLastStrike = 0;  
	SightSphere = PCIP.CreateDefaultSubobject <USphereComponent>(this, TEXT("SightSphere"));  
	SightSphere->AttachTo(RootComponent);  
	AttackRangeSphere = PCIP.CreateDefaultSubobject   <USphereComponent>(this, TEXT("AttackRangeSphere"));  AttackRangeSphere->AttachTo(RootComponent);
}

// Called when the game starts or when spawned
void AEnemy::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AEnemy::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);


	// basic intel: move the monster towards the player  
	AEnemy *avatar = Cast<AEnemy>(    
	UGameplayStatics::GetPlayerPawn(GetWorld(), 0) );

	if( !avatar ) return;  
	FVector toPlayer = avatar->GetActorLocation() -    GetActorLocation();  
	toPlayer.Normalize(); 
	// reduce to unit vector  
	// Actually move the monster towards the player a bit  
	AddMovementInput(toPlayer, Speed * DeltaSeconds);  
	// At least face the target  
	// Gets you the rotator to turn something  
	// that looks in the `toPlayer` direction  
	FRotator toPlayerRotation = toPlayer.Rotation();  
	toPlayerRotation.Pitch = 0; 
	// 0 off the pitch  
	RootComponent->SetWorldRotation( toPlayerRotation );

}

// Called to bind functionality to input
void AEnemy::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

