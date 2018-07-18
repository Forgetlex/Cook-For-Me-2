using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSensitive : MonoBehaviour {


    public float Temperature = 0;

    public float MaxTemperature = 1000;
    public float MinTemperature = -273;

    public float MaterialThermalConductivity = 1;
    public float CrossSectionalArea = 1;
    public float MaterialThickness = 1;

    HeatSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<HeatSource>();

        if(source != null)
        {
            InvokeRepeating("SetTemperature", 1.0f, 1.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetTemperature()
    {
        if(source != null)
        {
            source.Temperature = Temperature;
        }
    }

    public float HeatTransferFrom(HeatSensitive sensitive)
    {
        float Q = 0;

        if (Temperature > sensitive.Temperature)
        {
            Q = HeatTransfer(Temperature, sensitive.Temperature);
        }
        else if(sensitive.Temperature > Temperature)
        {
            Q = HeatTransfer(sensitive.Temperature, Temperature);
        }

        return Q;
    }

    public float HeatTransferFrom(HeatSource source)
    {
        float Q = 0;

        if (Temperature > source.Temperature)
        {
            Q = HeatTransfer(Temperature, source.Temperature);
        }
        else if (source.Temperature > Temperature)
        {
            Q = HeatTransfer(source.Temperature, Temperature);
        }

        return Q;
    }

    public float HeatTransfer(float high, float low)
    {
        float KA = (MaterialThermalConductivity) * (CrossSectionalArea);

        float Q = (KA * (high - low)) / MaterialThickness;

        return Q;
    }

    public void ApplyHeatTransfer(float Q)
    {
        Temperature += Q;

        if (Temperature > MaxTemperature) Temperature = MaxTemperature;
        if (Temperature < MinTemperature) Temperature = MinTemperature;
    }

    private void OnCollisionStay(Collision collision)
    {
        HeatSource source = collision.gameObject.GetComponent<HeatSource>();

        if(source != null)
        {
            ApplyHeatTransfer(HeatTransferFrom(source));
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        HeatSensitive sensitive = other.GetComponent<HeatSensitive>();

        if (sensitive != null)
        {
            ApplyHeatTransfer(HeatTransferFrom(sensitive));
        }
    }*/
}
