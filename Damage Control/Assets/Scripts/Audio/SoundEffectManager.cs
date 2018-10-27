using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;

    [SerializeField]
    private float effectsVolume = 1;
    [SerializeField]
    private SoundEffect[] effects;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null) { instance = this; }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
    }

    public void PlayEffect(string effectName)
    {
        if (effectName == "") return;
        SoundEffect s = Array.Find(effects, effect => effect.name == effectName); // this uses a Lambda Expression
        audioSource.PlayOneShot(s.audioClip, s.volume * effectsVolume);
    }
}