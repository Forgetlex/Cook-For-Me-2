using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journeys : MonoBehaviour {

    public List<JourneyStep> Steps = new List<JourneyStep>();
    public List<JourneyStep> StepsDone = new List<JourneyStep>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ProcessFlags();
	}

    void ProcessFlags()
    {
        List<JourneyStep> stepsToFlag = new List<JourneyStep>();
        foreach (JourneyStep step in Steps)
        {
            if (step.isDone())
            {
                stepsToFlag.Add(step);
            }
        }
        foreach (JourneyStep step in stepsToFlag)
        {
            Flag(step);
        }
    }

    void Flag(JourneyStep step)
    {
        StepsDone.Add(step);
        Steps.Remove(step);
    }
}
