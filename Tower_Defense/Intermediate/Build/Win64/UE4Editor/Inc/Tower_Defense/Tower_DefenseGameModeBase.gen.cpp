// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "Tower_Defense/Tower_DefenseGameModeBase.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeTower_DefenseGameModeBase() {}
// Cross Module References
	TOWER_DEFENSE_API UClass* Z_Construct_UClass_ATower_DefenseGameModeBase_NoRegister();
	TOWER_DEFENSE_API UClass* Z_Construct_UClass_ATower_DefenseGameModeBase();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_Tower_Defense();
// End Cross Module References
	void ATower_DefenseGameModeBase::StaticRegisterNativesATower_DefenseGameModeBase()
	{
	}
	UClass* Z_Construct_UClass_ATower_DefenseGameModeBase_NoRegister()
	{
		return ATower_DefenseGameModeBase::StaticClass();
	}
	struct Z_Construct_UClass_ATower_DefenseGameModeBase_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AGameModeBase,
		(UObject* (*)())Z_Construct_UPackage__Script_Tower_Defense,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::Class_MetaDataParams[] = {
		{ "Comment", "/**\n * \n */" },
		{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
		{ "IncludePath", "Tower_DefenseGameModeBase.h" },
		{ "ModuleRelativePath", "Tower_DefenseGameModeBase.h" },
		{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ATower_DefenseGameModeBase>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::ClassParams = {
		&ATower_DefenseGameModeBase::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		nullptr,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		0,
		0,
		0x009002ACu,
		METADATA_PARAMS(Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_ATower_DefenseGameModeBase()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_ATower_DefenseGameModeBase_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(ATower_DefenseGameModeBase, 3996244367);
	template<> TOWER_DEFENSE_API UClass* StaticClass<ATower_DefenseGameModeBase>()
	{
		return ATower_DefenseGameModeBase::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_ATower_DefenseGameModeBase(Z_Construct_UClass_ATower_DefenseGameModeBase, &ATower_DefenseGameModeBase::StaticClass, TEXT("/Script/Tower_Defense"), TEXT("ATower_DefenseGameModeBase"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ATower_DefenseGameModeBase);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
