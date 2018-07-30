using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyStep_ImpressGordonRamsey : JourneyStep {

    private AudioSource Source;

    List<GameObject> Steaks = new List<GameObject>();
    List<GameObject> Carrots = new List<GameObject>();

    public AudioClip RawClip;
    public AudioClip BurnedClip;
    public AudioClip PerfectClip;



    public override string GetName()
    {
        return "Impress Gordon Ramsey";
    }

    private static bool is_done = false;
    public override bool isDone()
    {
        return is_done;
    }

    public override void setDone(bool isdone)
    {
        is_done = isdone;
    }

    // Use this for initialization
    void Start () {
        Source = gameObject.AddComponent<AudioSource>();
    }

    public override bool Validate()
    {
        if (!ValidateSteaks())
            return false;
        if (!ValidateCarrots())
            return false;

        SetSourceClip(PerfectClip);
        setDone(true);
        return is_done;
    }

    public bool ValidateSteaks()
    {
        foreach(GameObject steak in Steaks)
        {
            if (!ValidateSteak(steak))
                return false;
        }
        if (Steaks.Count == 0)
            return false;
        return true;
    }

    private void SetSourceClip(AudioClip clip)
    {
        if(!Source.isPlaying)
        {
            Source.clip = clip;
            Source.Play();
        }
    }

    public bool ValidateSteak(GameObject steak)
    {
        Cookable cook = steak.GetComponent<Cookable>();
        if(cook.IsBurned)
        {
            SetSourceClip(BurnedClip);
            return false;
        }
        else if(!cook.IsCooked)
        {
            SetSourceClip(RawClip);
            return false;
        }

        return true;
    }

    public bool ValidateCarrots()
    {
        return Carrots.Count > 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Steak steak = collision.gameObject.GetComponent<Steak>();
        CuttedPiece cut = collision.gameObject.GetComponent<CuttedPiece>();

        if (steak != null && !Steaks.Contains(collision.gameObject))
            Steaks.Add(collision.gameObject);

        if (cut != null && !Carrots.Contains(collision.gameObject))
            Carrots.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Steak steak = collision.gameObject.GetComponent<Steak>();
        CuttedPiece cut = collision.gameObject.GetComponent<CuttedPiece>();

        if (steak != null && Steaks.Contains(collision.gameObject))
            Steaks.Remove(collision.gameObject);

        if (cut != null && Carrots.Contains(collision.gameObject))
            Carrots.Remove(collision.gameObject);
    }
}
