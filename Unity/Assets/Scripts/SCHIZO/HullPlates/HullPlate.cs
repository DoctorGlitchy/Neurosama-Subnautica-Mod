﻿using NaughtyAttributes;
using SCHIZO.Attributes.Visual;
using UnityEngine;

namespace SCHIZO.HullPlates
{
    [CreateAssetMenu(menuName = "SCHIZO/Hull Plates/Hull Plate")]
    public sealed class HullPlate : ScriptableObject
    {
        [Careful] public string classId;
        public string displayName;
        [HideIf(nameof(deprecated)), ResizableTextArea] public string tooltip;
        public Texture2D texture;
        [HideIf(nameof(deprecated)), Careful] public Texture2D overrideIcon;
        public bool expensive;
        [HideIf(nameof(deprecated))] public bool hidden = true;
        public bool deprecated;
    }
}
