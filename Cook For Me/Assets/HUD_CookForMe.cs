using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_CookForMe : MonoBehaviour {

    public GameObject Player;
    public Text JourneyDescription;
    public Text CurrentJourneyText;

    private Journeys Journey;
    private int StepsDoneCount = 0;
    private JourneyStep CurrentStep;

    private bool isCurrentJourneyShowed = false;


    // Use this for initialization
    void Start () {
        Journey = Player.GetComponent<Journeys>();
        if(Journey != null)
        {
            StepsDoneCount = Journey.StepsDone.Count;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(Journey != null)
        {
            ShowNextSteps(Journey.Steps);
            FindCurrentStepDone(Journey.StepsDone);
        } 
	}

    void ShowNextSteps(List<JourneyStep> steps)
    {
        string text = "";
        int count = 0;
        foreach (JourneyStep step in steps)
        {
            text += (++count).ToString() + " : " + step.GetName() + "\n";
        }
        JourneyDescription.text = text;
    }

    void FindCurrentStepDone(List<JourneyStep> steps)
    {
        if(StepsDoneCount != steps.Count)
        {
            CurrentStep = steps[steps.Count-1];
            ShowStep(CurrentStep);
            StepsDoneCount = steps.Count;
        }
    }

    void ShowStep(JourneyStep step)
    {
        CurrentJourneyText.text = step.GetName();
        StartCoroutine(HideCurrentJourney(3));
    }

    IEnumerator HideCurrentJourney(float time)
    {
        if (isCurrentJourneyShowed)
            yield break;

        isCurrentJourneyShowed = true;

        yield return new WaitForSeconds(time);

        CurrentJourneyText.text = "";

        isCurrentJourneyShowed = false;
    }
}
