using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour {

    public Vector3 localPosChange = new Vector3(0, 0, 0);
    public Vector3 localScaleChange = new Vector3(0, 0, 0);

    public int CooldownInSeconds = 1;

    public GameObject FirstChild;

    public GameObject LastChild;

    public GameObject GameChild;

    public GameObject IgnoreCollider;

    public int childrenCount = 0;
	// Use this for initialization
	void Start () {

       // Physics.IgnoreCollision(IgnoreCollider.GetComponent<Collider>(), GetComponent<Collider>());

        for (int i = 0; i < childrenCount; ++i)
        {
            GameObject obj = Instantiate(GameChild);
            obj.transform.parent = gameObject.transform;
            for (int j = 0; j < i; ++j)
            {
                obj.transform.position += localPosChange;
                obj.transform.localScale += localScaleChange;
            }
            if (i > 0)
            {
                //obj.GetComponent<FixedJoint>().connectedBody = transform.GetChild(i-1).gameObject.GetComponent<Rigidbody>();
                //obj.transform.parent = gameObject.transform.GetChild(i - 1);
            }
        }
    }

    void DropLast()
    {
        GameObject child = gameObject.transform.GetChild(transform.childCount-1).gameObject;
        child.transform.parent = null;
        child.gameObject.AddComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider collider)
    {
        Knife knife = collider.GetComponent<Knife>();
        if (knife != null)
        {
            DropLast();
        }
    }

    /*void OnCollisionEnter(Collision collision)
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
    }*/

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
