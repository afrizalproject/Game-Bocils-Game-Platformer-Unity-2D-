using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsoungGamePlay : MonoBehaviour
{
    public static backsoungGamePlay singleton;
    public bool audioMute;
    public AudioSource audio;

    private void Awake()
    {
        singleton = this;
        audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioMute)
        {
            audio.mute=true;
        }
        else
        {
            audio.mute = false;
        }
    }
}
