using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponControll : MonoBehaviour {


    public float speed = 1;
    public float fireRate = 2.0f;
    public float firstShotDelay = 2.0f;
    public GameObject bullet;
    public Transform shotspawn;

    private AudioSource audioSource;


    void Start()
    {
        InvokeRepeating("Bullet", firstShotDelay, fireRate);
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;
        audioSource = GetComponent<AudioSource>();

    }

    void Bullet()
    {
        Instantiate(bullet, shotspawn.position, shotspawn.rotation);
        audioSource.Play();
    }

}
