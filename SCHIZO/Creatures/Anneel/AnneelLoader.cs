﻿using System.Collections.Generic;
using SCHIZO.Attributes;
using SCHIZO.Helpers;
using SCHIZO.Resources;
using SCHIZO.Unity.Creatures;

namespace SCHIZO.Creatures.Anneel;

[LoadCreature]
public sealed class AnneelLoader : CustomCreatureLoader<CustomCreatureData, AnneelPrefab, AnneelLoader>
{
    public AnneelLoader() : base(Assets.Anneel_AnneelData)
    {
        PDAEncyPath = "Lifeforms/Fauna/LargeHerbivores";
    }

    protected override AnneelPrefab CreatePrefab()
    {
        return new AnneelPrefab(ModItems.Anneel, creatureData.regularPrefab);
    }

    protected override IEnumerable<LootDistributionData.BiomeData> GetLootDistributionData()
    {
        foreach (BiomeType biome in BiomeHelpers.GetOpenWaterBiomes())
        {
            yield return new LootDistributionData.BiomeData { biome = biome, count = 1, probability = 0.005f };
        }
    }
}