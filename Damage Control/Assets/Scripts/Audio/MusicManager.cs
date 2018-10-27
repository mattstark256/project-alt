using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] turnMusic;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;

        if (turnMusic[0] != null)
        {
            audioSource.clip = turnMusic[0];
            audioSource.Play();
        }
    }

    public void SwitchMusic(int turnNumber)
    {
        if (turnNumber >= turnMusic.Length) { Debug.Log("No music found for turn " + turnNumber); return; }
        if (turnMusic[turnNumber] == null) { audioSource.Stop(); }
        if (audioSource.clip == turnMusic[turnNumber]) { return; }
        audioSource.clip = turnMusic[turnNumber];
        audioSource.Play();
    }
}
