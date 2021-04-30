// Copyright Epic Games, Inc. All Rights Reserved.

#include "CoopFinalGameMode.h"
#include "CoopFinalCharacter.h"
#include "UObject/ConstructorHelpers.h"

ACoopFinalGameMode::ACoopFinalGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
