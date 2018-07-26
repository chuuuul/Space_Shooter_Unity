using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    public float scrollspeed = 0.25f;
    public float tileLen;
    private Vector3 startPoint;

    void Start()
    {
        startPoint = transform.position;
        tileLen = GetComponent<Transform>().localScale.y;
    }

    void Update()
    {
        transform.position = startPoint + Vector3.forward * Mathf.Repeat( Time.time * -scrollspeed, tileLen) ;      // Background Move with time
    }

}
