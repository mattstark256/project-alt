using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    public string name;
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume = 0.8f;
}
