﻿using System.Collections;
using Nautilus.Handlers;
using UnityEngine;

namespace SCHIZO.Utilities.Sounds;

public sealed class SoundCollection2D : SoundCollection
{
    private SoundCollection2D() {}

    public static SoundCollection2D Create(string path, string bus)
    {
        SoundCollection2D result = CreateInstance<SoundCollection2D>();
        result.Initialize(path, bus);
        return result;
    }

    protected override void RegisterSound(string id, string soundFile, string bus) => CustomSoundHandler.RegisterCustomSound(id, soundFile, bus);

    public void Play(float delay = 0)
    {
        if (CONFIG.DisableAllNoises) return;

        if (delay == 0)
        {
            PlaySound();
            return;
        }

        StartSoundCoroutine(PlayWithDelay(delay));
        return;

        IEnumerator PlayWithDelay(float del)
        {
            yield return new WaitForSeconds(del);
            PlaySound();
        }
    }

    private void PlaySound()
    {
        LastPlay = Time.time;

        if (_remainingSounds.Count == 0)
        {
            _remainingSounds.AddRange(_playedSounds);
            _playedSounds.Clear();
        }

        CustomSoundHandler.TryPlayCustomSound(_remainingSounds[0], out _);
        _playedSounds.Add(_remainingSounds[0]);
        _remainingSounds.RemoveAt(0);
    }
}