using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    //Déclaration des variables
    public AudioSource Source;
    public AudioClip[] myMusic = new AudioClip[3];

    void Awake()
    {
    }

    void Start()
    {
        Source = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Source.isPlaying)
            playRandomMusic();
    }

    void playRandomMusic()
    {
        Source.clip = myMusic[Random.Range(0, myMusic.Length)];
        Source.Play();
    }
}
