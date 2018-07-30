using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour {

    // Audio Source for collision types
    private AudioSource AudioEnter;
    private AudioSource AudioStay;
    private AudioSource AudioExit;

    public AudioClip ClipEnter;
    public AudioClip ClipStay;
    public AudioClip ClipExit;

    // What to detect
    public string Script;
    public string Tag;

	// Use this for initialization
	void Start () {
        UpdateSources();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateSources()
    {
        if (AudioEnter == null)
            AudioEnter = CreateSourceFor(ClipEnter);
        else
            AudioEnter.clip = ClipEnter;

        if (AudioStay == null)
        {
            AudioStay = CreateSourceFor(ClipStay);
            AudioStay.loop = true;
        }
        else
            AudioStay.clip = ClipStay;

        if (AudioExit == null)
            AudioExit = CreateSourceFor(ClipExit);
        else
            AudioExit.clip = ClipExit;
    }

    AudioSource CreateSourceFor(AudioClip audio)
    {
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = audio;
        source.spatialBlend = 1.0f;
        source.maxDistance = 3.0f;

        return source;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (AudioEnter != null)
            PlaySoundIfMatch(collision.gameObject, AudioEnter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AudioEnter != null)
            PlaySoundIfMatch(other.gameObject, AudioEnter);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(AudioStay != null)
            PlaySoundIfMatch(collision.gameObject, AudioStay);
    }

    private void OnTriggerStay(Collider other)
    {
        if (AudioStay != null)
            PlaySoundIfMatch(other.gameObject, AudioStay);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (AudioStay != null)
            AudioStay.Stop();
        if (AudioExit != null)
            PlaySoundIfMatch(collision.gameObject, AudioExit);
    }

    private void OnTriggerExit(Collider other)
    {
        if (AudioStay != null)
            AudioStay.Stop();
        if (AudioExit != null)
            PlaySoundIfMatch(other.gameObject, AudioExit);
    }

    private void PlaySoundIfMatch(GameObject obj, AudioSource source)
    {
        Component script = null;
        if(Script != null)
            script = obj.GetComponent(Script);
        string tag = obj.tag;
        if (script != null || (tag != "" && Tag.Equals(tag)))
        {
            if ((!source.loop || (source.loop && !source.isPlaying)) && Time.timeSinceLevelLoad > 1)
            {
                source.Play();
            }
        }
    }
}
