using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGrabbable : MonoBehaviour {

    OVRGrabbable grab;

    // Use this for initialization
    void Start () {
        grab = gameObject.AddComponent<OVRGrabbable>();
        grab.DetectGrabPoints();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
