using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxmanager : MonoBehaviour
{
    public static sfxmanager singleton;
    public AudioClip[] clips;
    AudioSource audioSource;

    private void Awake()
    {
        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void playSound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
