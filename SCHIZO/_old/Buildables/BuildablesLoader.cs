﻿using System.Diagnostics.CodeAnalysis;
using Nautilus.Crafting;
using SCHIZO.Attributes;
using SCHIZO.Resources;

namespace SCHIZO.Buildables;

[LoadMethod]
public static class BuildablesLoader
{
    [LoadMethod]
    [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
    private static void Load()
    {
        /*LoadOldVersions();

        new BuildableItem(new ModItem("VedalTurtle4", "Fake tutel", "that's crazy\n<size=75%>(Model by FutabaKuuhaku)</size>"))
        {
            UnityItemData = Assets.Tutel_BuildableTutelData,
            Recipe = new RecipeData(new Ingredient(TechType.CreepvinePiece, 10), new Ingredient(ModItems.Tutel, 1)),
            TechGroup = TechGroup.Miscellaneous,
            TechCategory = TechCategory.Misc,
            RequiredForUnlock = ModItems.Tutel,
        }.WithOldVersion("VedalTurtle3").Register();

        new BuildableItem(ModItems.Erm)
        {
            UnityItemData = Assets.Erm_BuildableErmData,
            Recipe = new RecipeData(new Ingredient(TechType.CopperWire, 2), new Ingredient(TechType.Silicone, 2), new Ingredient(TechType.Battery, 1), new Ingredient(TechType.Titanium, 4), new Ingredient(ModItems.Ermfish, 1)),
            TechGroup = TechGroup.Miscellaneous,
            TechCategory = TechCategory.Misc,
            RequiredForUnlock = ModItems.Ermfish,
        }.Register();

        new BuildableItem(new ModItem("Neuroopper2", "Neurooper", "<size=75%>(Model by greencap, original art by Sandro)</size>"))
        {
            UnityItemData = Assets.Neurooper_NeurooperData,
            Recipe = new RecipeData(new Ingredient(TechType.CopperWire, 1), new Ingredient(TechType.Silicone, 2), new Ingredient(Retargeting.TechType.Peeper, 2), new Ingredient(TechType.Bladderfish, 1)),
            TechGroup = TechGroup.Miscellaneous,
            TechCategory = TechCategory.Misc,
        }.WithOldVersion("Neurooper").Register();

        new BuildableItem(new ModItem("NeuroFumo2", "Low-poly Neuro fumo", "Fumo collection 1/2\n<size=75%>(Model by YuG)</size>"))
        {
            UnityItemData = Assets.LowPolyNeurofumo_LowpolyFumoData,
            Recipe = new RecipeData(new Ingredient(TechType.CopperWire, 1), new Ingredient(TechType.Silicone, 2), new Ingredient(TechType.JeweledDiskPiece, 1), new Ingredient(TechType.Gold, 1)),
            TechGroup = TechGroup.Miscellaneous,
            TechCategory = TechCategory.Misc,
        }.WithOldVersion("NeuroFumo").Register();*/

        new BuildableItem(new ModItem("NeuroFumoNew", "Neuro fumo", "Fumo collection 2/2\n<size=75%>(Model by Kat)</size>"))
        {
            UnityItemData = Assets.Neurofumo_FumoData,
            Recipe = new RecipeData(new Ingredient(TechType.CopperWire, 1), new Ingredient(TechType.Silicone, 2), new Ingredient(TechType.JeweledDiskPiece, 1), new Ingredient(TechType.Gold, 1)),
            TechGroup = TechGroup.Miscellaneous,
            TechCategory = TechCategory.Misc,
        }.Register();
    }

    [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
    private static void LoadOldVersions()
    {
        new BuildableItem(new ModItem("NeuroErm", "Erm (OLD VERSION, PLEASE REBUILD)", "<size=75%>(Model by w1n7er)</size>"))
        {
            UnityItemData = Assets.Erm_BuildableErmData,
            Recipe = new RecipeData(new Ingredient(TechType.CopperWire, 2), new Ingredient(TechType.Silicone, 2), new Ingredient(TechType.Battery, 1), new Ingredient(TechType.Titanium, 4)),
            DisableSounds = true
        }.Register();

        new BuildableItem(new ModItem("VedalTurtle2", "Fake tutel (OLD VERSION, PLEASE REBUILD)", "that's crazy\n<size=75%>(Model by FutabaKuuhaku)</size>"))
        {
            UnityItemData = Assets.Tutel_BuildableTutelData,
            Recipe = new RecipeData(new Ingredient(TechType.CreepvinePiece, 10)),
            DisableSounds = true
        }.WithOldVersion("VedalTurtle").Register();
    }
}