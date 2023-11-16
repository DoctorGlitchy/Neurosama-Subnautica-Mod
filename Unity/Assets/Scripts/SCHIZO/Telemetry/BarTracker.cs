using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace SCHIZO.Telemetry
{
    public sealed partial class BarTracker : TelemetrySource
    {
        [Serializable]
        private partial class TrackedBar
        {
            public string barName;
            public string componentTypeName;
            public string valueMemberName;
            public string maxMemberName;
            [ShowIf(nameof(maxValue_ShowIf))] public float maxValue = 100;
            [InfoBox("The first threshold is the 'critical' percentage, and the second is the 'low' percentage")]
            public Vector2 thresholds;

            private bool maxValue_ShowIf() => string.IsNullOrWhiteSpace(maxMemberName);
        }

        [ListDrawerSettings(AlwaysExpanded = true), SerializeField]
        private List<TrackedBar> trackedProperties;
    }
}