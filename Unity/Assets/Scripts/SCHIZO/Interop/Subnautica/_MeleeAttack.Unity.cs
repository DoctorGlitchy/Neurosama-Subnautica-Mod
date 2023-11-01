﻿using NaughtyAttributes;
using SCHIZO.Attributes.Typing;
using SCHIZO.Utilities;
using UnityEngine;

namespace SCHIZO.Interop.Subnautica
{
    partial class _MeleeAttack : MonoBehaviour
    {
        [Required] public GameObject mouth;
        [Required] public Animator animator;

        public float biteInterval = 1;
        public float biteDamage = 30;
        public bool canBitePlayer = true;
        public bool canBiteVehicle = false;
        public bool canBiteCyclops = false;
        public bool canBiteCreature = true;
        public bool ignoreSameKind = false;
        public bool canBeFed = true;

        [Foldout(STRINGS.COMPONENT_REFERENCES), Required, ExposedType("LastTarget")] public MonoBehaviour lastTarget;
        [Foldout(STRINGS.COMPONENT_REFERENCES), Required] public _Creature creature;
        [Foldout(STRINGS.COMPONENT_REFERENCES), Required, ExposedType("LiveMixin")] public MonoBehaviour liveMixin;

        [Foldout(STRINGS.UNCHANGED_BY_ECC)] public float biteAggressionThreshold = 0.3f;
        [Foldout(STRINGS.UNCHANGED_BY_ECC)] public float eatHungerDecrement = 0.5f;
        [Foldout(STRINGS.UNCHANGED_BY_ECC)] public float eatHappyIncrement = 0.5f;
        [Foldout(STRINGS.UNCHANGED_BY_ECC)] public float biteAggressionDecrement = 0.4f;
        [Foldout(STRINGS.UNCHANGED_BY_ECC)] public GameObject damageFX;

        [Foldout(STRINGS.UNCHANGED_BY_ECC), ReadOnly] public Object _attackSound;

        public void OnTouch(Collider col) {}
    }
}