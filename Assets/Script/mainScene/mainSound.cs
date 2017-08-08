using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSound : MonoBehaviour {

    public AudioClip sound;
    AudioSource MyAUdio;

	// Use this for initialization
	void Start () {
        MyAUdio = GetComponent<AudioSource>();
        MyAUdio.clip = sound;
        MyAUdio.loop = true;
        MyAUdio.Play();
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
