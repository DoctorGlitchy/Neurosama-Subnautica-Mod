﻿using NaughtyAttributes;
using SCHIZO.Interop.Subnautica;
using SCHIZO.Interop.Subnautica.Enums;
using SCHIZO.Utilities;
using UnityEngine;

[RequireComponent(typeof (LastTarget))]
[RequireComponent(typeof (CreatureFear))]
public class AggressiveWhenSeeTarget : MonoBehaviour
{
    [Foldout(STRINGS.COMPONENT_REFERENCES), Required] public LastTarget lastTarget;
    [Foldout(STRINGS.COMPONENT_REFERENCES), Required] public _Creature creature;

    public AnimationCurve maxRangeMultiplier = ECCLIBRARY.maxRangeMultiplierCurve;
    public AnimationCurve distanceAggressionMultiplier = ECCLIBRARY.distanceAggressionMultiplierCurve;
    public EcoTargetType_All targetType = EcoTargetType_All.Shark;
    public float aggressionPerSecond = 1;
    public float maxRangeScalar = 10;
    public int maxSearchRings = 1;
    public bool ignoreSameKind = true;
    public float minimumVelocity = 0;
    public float hungerThreshold = 0;

    [Foldout(STRINGS.UNCHANGED_BY_ECC)] public bool ignoreFrozen = false;
    [Foldout(STRINGS.UNCHANGED_BY_ECC)] public float leashDistance = -1;
    [Foldout(STRINGS.UNCHANGED_BY_ECC)] public float targetPriority = 1;
    [Foldout(STRINGS.UNCHANGED_BY_ECC)] public FMODAsset sightedSound;
}
