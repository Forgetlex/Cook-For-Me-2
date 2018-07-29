using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyStep_CookedSteak : JourneyStep {

    private string name = "Cook a Steak";
    public override string GetName()
    {
        return name;
    }

    public static bool is_done;
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
        Cookable cook = GetComponent<Cookable>();
        if (cook != null && cook.IsCooked)
        {
            is_done = true;
        }
        return is_done;
    }
}
