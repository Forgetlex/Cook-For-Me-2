using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyStep_OpenFridge : JourneyStep {

    public override string GetName()
    {
        return "Open the Fridge";
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
		
	}

    public override bool Validate()
    {
        Frigo fridge = gameObject.GetComponent<Frigo>();
        if (fridge != null && fridge.isOpen)
            setDone(true);
        return is_done;
    }
}
