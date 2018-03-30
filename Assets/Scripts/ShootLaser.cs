using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShootLaser : MonoBehaviour {


    //LineRenderer beam;
    Ray ray;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
        //beam = gameObject.GetComponent<LineRenderer>();
        //beam.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            FireLaser();
        }

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.tag);
        }
	}

    void FireLaser()
    {
        //beam.enabled = true;

        ray = new Ray(transform.position, transform.forward);
        //beam.SetPosition(0, ray.origin);
        //beam.SetPosition(1, ray.GetPoint(100));

        //beam.enabled = false;
        Debug.Log("FIREDDDDDD!!!");
    }

    public void OnClickFire()
    {
        FireLaser();
        Debug.Log("Button clicked");
    }
}
