using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour {

    public float rotationSpeed = 5;
	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationSpeed;

    }
	

}
