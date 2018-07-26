using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed = 20.0f;

	void Start ()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;

	}
	


}
