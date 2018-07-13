using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigo : MonoBehaviour {

    bool isOpen = false;
    bool canBeOpen = true;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CanBeOpen", 1.0f, 2.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(canBeOpen && other.GetComponent<OVRGrabber>() != null)
        {
            if(!isOpen)
                transform.parent.GetComponent<Animation>().Play("open");
            else
                transform.parent.GetComponent<Animation>().Play("close");

            isOpen = !isOpen;
            canBeOpen = false;
        }
    }

    void CanBeOpen()
    {
        canBeOpen = true;
    }
}
