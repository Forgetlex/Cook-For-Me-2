using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

    bool isCutting = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCutting();
        }
	}

    void UpdateCutting()
    {

    }

    void StartCutting()
    {
        isCutting = true;
    }

    void StopCutting()
    {
        isCutting = false;
    }
}
