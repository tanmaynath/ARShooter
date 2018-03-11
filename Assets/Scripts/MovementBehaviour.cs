using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour {

    public float spinSpeed;


    // Give waypoint/movement paths
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitCircle * spinSpeed;
	}
	
	
}
