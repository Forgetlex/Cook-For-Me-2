using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JourneyStep : MonoBehaviour {


    public abstract string GetName();

    public abstract bool isDone();
    public abstract void setDone(bool isdone);

    public bool FlagAsRead;

    public abstract bool Validate();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDone())
        {
            setDone(Validate());
        }
	}
}
