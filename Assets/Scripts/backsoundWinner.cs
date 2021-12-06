using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsoundWinner : MonoBehaviour
{
    public static backsoundWinner singleton;
    public bool audioMute;
    public AudioSource audio;

    private void Awake()
    {
        singleton = this;
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioMute)
        {
            audio.mute = true;
        }
        else
        {
            audio.mute = false;
        }
    }
}
