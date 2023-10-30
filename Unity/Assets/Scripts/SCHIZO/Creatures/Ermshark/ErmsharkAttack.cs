﻿using JetBrains.Annotations;
using NaughtyAttributes;
using SCHIZO.Attributes.Typing;
using SCHIZO.Interop.Subnautica;
using SCHIZO.Sounds;
using UnityEngine;

namespace SCHIZO.Creatures.Ermshark
{
    public sealed partial class ErmsharkAttack : _MeleeAttack
    {
        [BoxGroup("Sounds"), SerializeField, Required, UsedImplicitly]
        private SoundCollection attackSounds;

        [BoxGroup("Sounds"), SerializeField, Required, UsedImplicitly]
        private _FMOD_CustomEmitter emitter;
    }
}
