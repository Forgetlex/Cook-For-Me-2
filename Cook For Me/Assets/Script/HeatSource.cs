using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSource : MonoBehaviour {

    public float Temperature;

    public float MaxTemperature;
    public float MinTemperature;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTemperature(float temp)
    {
        Temperature = temp;

        if (Temperature > MaxTemperature) Temperature = MaxTemperature;
        if (Temperature < MinTemperature) Temperature = MinTemperature;
    }

    private void OnTriggerStay(Collider other)
    {
        HeatSensitive sensitive = other.GetComponent<HeatSensitive>();
        HeatSource source = other.GetComponent<HeatSource>();

        if(sensitive != null)
        {

        }
        if(source != null)
        {

        }
    }
}
