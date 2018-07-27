using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPos : MonoBehaviour {

    public GameObject toCopy;
    public Vector3 appliedTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = toCopy.transform.position;

        transform.position += appliedTransform;

	}
}
