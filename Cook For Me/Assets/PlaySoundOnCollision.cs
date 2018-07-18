using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour {

    // Audio Source for collision types
    public AudioSource AudioEnter;
    public AudioSource AudioStay;
    public AudioSource AudioExit;

    // What to detect
    public string Script;
    public string Tag;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        PlaySoundIfMatch(collision, AudioEnter);
    }

    private void OnCollisionStay(Collision collision)
    {
        PlaySoundIfMatch(collision, AudioStay);
    }

    private void OnCollisionExit(Collision collision)
    {
        AudioStay.Stop();
        PlaySoundIfMatch(collision, AudioExit);
    }

    private void PlaySoundIfMatch(Collision col, AudioSource source)
    {
        Component script = null;
        if(Script != null)
            script = col.gameObject.GetComponent(Script);
        string tag = col.gameObject.tag;
        if (script != null || (tag != "" && Tag.Equals(tag)))
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}
