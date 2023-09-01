﻿using System.Collections.Generic;
using System.Linq;
using SCHIZO.Buildables;
using SCHIZO.Creatures.Ermfish;
using SCHIZO.Utilities;
using UnityEngine;

namespace SCHIZO.Events;

public class ErmConEvent : MonoBehaviour, ICustomEvent
{
    public string Name => "ErmCon";

    public bool IsOccurring => ConMembers.Count > 0;

    public int MinAttendance = 10;
    public int MaxAttendance = 50;
    public float SearchRadius = 250f;
    public float ErmQueenSearchRadius = 50f;
    public float EventDurationSeconds = 120f;
    public float CooldownSeconds = 3600f;

    public bool OnlyStare;

    public GameObject CongregationTarget;

    private readonly List<Creature> ConMembers = new();
    private float _eventStartTime;
    private bool _hasRolled;

    private void Awake()
    {
        // let's not start 
        _eventStartTime = -CooldownSeconds/2;
    }
    private bool ShouldStartEvent()
    {
        if (Time.time < _eventStartTime + EventDurationSeconds + CooldownSeconds)
            return false;
        // roll 10% every 6 hours (5m irl)
        // should average out to about one con every 1-2h irl time (~45% in 1.5h, ~70% in 2h)
        // since it's always centered on (or around) the player, it's not a big problem that it's rare
        float normalDayScalar = DayNightUtils.dayScalar - 0.125f;
        if (normalDayScalar % 0.25 < 0.01)
        {
            if (_hasRolled)
                return false;
            _hasRolled = true;
            if (Random.Range(0f, 1f) > 0.1f)
                return false;
        }
        else
        {
            _hasRolled = false;
            return false;
        }

        // When more than ten Ermfish gather in one place, a hierarchical society (also known as a "swarm") begins to form, with the Queen Erm at the top.
        // If a Queen Erm cannot be located or designated, the swarm becomes distressed, and seeks the closest possible intelligent(?) being capable of designating the Queen for the swarm.
        // It is not currently known whether Ermfish swarms devolve if deprived of their Queen for too long.
        // Everyone who has so far been resourceful enough to survive on 4546B has displayed sufficient sensibility in choosing not to test that theory.
        int ermsInRange = AreaUtils.ObjectsInRange(CongregationTarget, SearchRadius)
            .ThatHaveComponent<ErmfishNoises>()
            .Count();
        if (ermsInRange < MinAttendance)
        {
            Debug.Log($"Rolled for ErmCon event but only had {ermsInRange} erms, unlucky");
            return false;
        }
        return true;
    }

    private float _lastSearchTime;
    private float _minSearchInterval = 1f;
    private float _stareTime;
    private void Update()
    {
        if (!CongregationTarget) // reset/default to player
        {
            CongregationTarget = gameObject;
            OnlyStare = true;
        }
        if (!IsOccurring)
        {
            if (!ShouldStartEvent()) return;
            StartEvent();
        }
        else
        {
            if (Time.time > _eventStartTime + EventDurationSeconds)
            {
                EndEvent();
                return;
            }

            // ermfish will stay still for 10s at the start of the event
            if (OnlyStare)
            {
                _stareTime += Time.deltaTime;
                if (_stareTime > 10)
                {
                    _stareTime = 0;
                    OnlyStare = false;
                }
            }

            // update focal point to buildable erm if there's one in range
            bool haveQueen = CongregationTarget.GetComponent<ErmNoises>();
            if (!haveQueen && !OnlyStare
                && Time.time > _lastSearchTime + _minSearchInterval)
            {
                if (TryFindErmQueen(gameObject, out ErmNoises ermBeacon))
                    CongregationTarget = ermBeacon.gameObject;
                _lastSearchTime = Time.time;
            }

            List<Creature> fishPlural = ConMembers.ToList();
            foreach (Creature fish in fishPlural)
            {
                if (!fish)
                {
                    ConMembers.Remove(fish);
                    continue;
                }
                SwimBehaviour swim = fish.GetComponent<SwimBehaviour>();
                // stop!
                fish.actions.Clear();
                if (OnlyStare)
                    // stop!!!
                    swim.Idle();
                else
                {
                    // stop swimming away!!!!!
                    Vector3 targetPos = CongregationTarget.transform.position;
                    if (haveQueen)
                    {
                        float mayorPersonalSpaceRange = 3f;
                        Vector3 directionToTarget = Vector3.Normalize(targetPos - swim.transform.position);
                        targetPos -= mayorPersonalSpaceRange * directionToTarget;
                    }
                    swim.SwimTo(targetPos, haveQueen ? 2f : 1f);

                }
                // stop looking away, too!!!!!!!
                swim.LookAt(CongregationTarget.transform);
            }
        }
    }

    public void StartEvent()
    {
        OnlyStare = true;
        if (!CongregationTarget)
            CongregationTarget = gameObject;

        List<Creature> withinRadius = AreaUtils.ObjectsInRange(CongregationTarget, SearchRadius)
            .ThatHaveComponent<ErmfishNoises>()
            .OrderBy(creature => creature.gameObject.transform.position.DistanceSqrXZ(CongregationTarget.transform.position))
            .ToComponent<Creature>()
            .ToList();
        int totalAttendance = Mathf.Min(MaxAttendance, withinRadius.Count);
        for (int i = 0; i < totalAttendance; i++)
        {
            Creature fish = withinRadius[i];
            Debug.Log($"{totalAttendance} Ermfish will be attending the ErmCon");
            ConMembers.Add(fish);
        }
        _eventStartTime = Time.time;
    }

    public void EndEvent()
    {
        CongregationTarget = null;
        foreach (Creature fish in ConMembers)
        {
            if (!fish) continue;
            fish.ScanCreatureActions();
            fish.GetComponent<SwimBehaviour>().LookForward();
        }
        ConMembers.Clear();
    }

    private bool TryFindErmQueen(GameObject center, out ErmNoises ermQueen)
    {
        ermQueen = null;
        IEnumerable<ErmNoises> ermBuildables = AreaUtils.ObjectsInRange(center, ErmQueenSearchRadius)
            .Select(obj => obj.GetComponentInParent<ErmNoises>())
            .Where(comp => comp)
            .OrderBy(comp => comp.transform.position.DistanceSqrXZ(center.transform.position));
        if (ermBuildables.FirstOrDefault() is { } ermQueen_)
        {
            ermQueen = ermQueen_;
            return true;
        }
        return false;
    }
}
