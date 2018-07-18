using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour {

    public Material RawMaterial;
    public Material CookedMaterial;
    public Material BurnedMaterial;

    // Seconds to cook
    public float SecondsToCook;
    public float SecondsToBurn;

    private bool isCooked = false;
    public bool IsCooked {
        get { return isCooked; }
        private set { isCooked = value; }
    }

    private bool isBurned = false;
    public bool IsBurned
    {
        get { return isBurned; }
        private set { isBurned = value; }
    }

    // Temperature at which it cooks
    public float CookingTemperature = 50;


    // HeatSensitive data related to the Cookable
    private HeatSensitive Heat;

    private List<HeatSource> sources = new List<HeatSource>();

    // The Cookable has been cooking for how many seconds
    public float HasBeenCookingFor = 0;

	// Use this for initialization
	void Start () {
        Heat = gameObject.GetComponent<HeatSensitive>();

        if (Heat == null)
            Debug.LogError("GameObject must have a HeatSensitive Component");

        gameObject.GetComponent<Renderer>().material = RawMaterial;

        InvokeRepeating("Cook", 1.0f, 1.0f);

        InvokeRepeating("SetTemperature", 1.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update() { 
	}

    void SetTemperature()
    {
        if(sources.Count == 0)
        {
            Heat.Temperature = 21;
        }
        else
        {
            foreach(HeatSource source in sources)
            {
                Heat.ApplyHeatTransfer(Heat.HeatTransferFrom(source));
            }
        }
    }

    void Cook()
    {
        if(Heat.Temperature > CookingTemperature)
        {
            HasBeenCookingFor++;
        }

        if(!IsBurned && HasBeenCookingFor > SecondsToBurn)
        {
            IsCooked = false;
            IsBurned = true;
            gameObject.GetComponent<Renderer>().material = BurnedMaterial;
        }
        else if (!IsBurned && !IsCooked && HasBeenCookingFor > SecondsToCook)
        {
            IsCooked = true;
            gameObject.GetComponent<Renderer>().material = CookedMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HeatSource source = collision.gameObject.GetComponent<HeatSource>();

        if (source != null)
        {
            sources.Add(source);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        HeatSource source = collision.gameObject.GetComponent<HeatSource>();

        if (source != null)
        {
            sources.Remove(source);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        HeatSource source = other.GetComponent<HeatSource>();

        if(source != null)
        {
            sources.Add(source);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HeatSource source = other.GetComponent<HeatSource>();

        if (source != null)
        {
            sources.Remove(source);
        }
    }*/
}
