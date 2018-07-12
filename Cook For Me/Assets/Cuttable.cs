using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour {

    public int CooldownInSeconds = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Knife knife = collision.gameObject.GetComponent<Knife>();

        if(knife != null && collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            //Debug.Log(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            Split(contact);
            StartCoroutine(Wait(CooldownInSeconds));
        }
    }

    void Split(ContactPoint contact)
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        
        Vector3 newSize = new Vector3(Mathf.Abs(pos.x - transform.position.x), Mathf.Abs(pos.y - transform.position.y), Mathf.Abs(pos.z - transform.position.z));
        Debug.Log( newSize.x + " : " + newSize.y + " : " + newSize.z);
        this.transform.localScale -= new Vector3(transform.localScale.x / 2.0f, transform.localScale.y / 2.0f, transform.localScale.z / 2.0f);
        //Instantiate(transform, pos, rot);
    }

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
