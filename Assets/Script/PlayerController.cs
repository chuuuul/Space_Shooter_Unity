using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public float speed = 1;
    public float tilt = 3;
    public float fireRate = 0.25f;
    public GameObject shootBullet;
    public Transform shootRespone;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shootBullet, shootRespone.position, shootRespone.rotation);
            this.GetComponent<AudioSource>().Play();
            
        }
    }
    
    
    void FixedUpdate()
    {
        float moveHorizon = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizon, 0.0f, moveVertical);

        this.GetComponent<Rigidbody>().velocity = movement * speed;

        this.GetComponent<Transform>().position = new Vector3
            (Mathf.Clamp(this.GetComponent<Transform>().position.x, boundary.xMin, boundary.xMax)
            , 0.0f
            , Mathf.Clamp(this.GetComponent<Transform>().position.z, boundary.zMin, boundary.zMax));

        this.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 0.0f, this.GetComponent<Rigidbody>().velocity.x * -tilt);
    }


}
