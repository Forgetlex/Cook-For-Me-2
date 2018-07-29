using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyStep_CutACarrot : JourneyStep {

    int childCount = 0;

    public override string GetName()
    {
        return "Cut A Carrot"; 
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
    void Start ()
    {
        childCount = transform.childCount;
	}

    public override bool Validate()
    {
        if (childCount != transform.childCount)
        {
            is_done = true;
        }
        return is_done;
    }
}
