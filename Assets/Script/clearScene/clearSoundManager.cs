using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearSoundManager : MonoBehaviour {
    public AudioClip sound;
    AudioSource MyAUdio;

    // Use this for initialization
    void Start()
    {
        MyAUdio = GetComponent<AudioSource>();
        MyAUdio.clip = sound;
        MyAUdio.loop = true;
        MyAUdio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
