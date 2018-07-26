using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public int score = 100;

    private GameController gameController;

    void Start()
    {
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Cannot find 'Game Controller' script");
        }
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" )
            return;

        
        if (other.tag == "Player")      //Player Destroy
        {
            Instantiate(playerExplosion, other.GetComponent<Rigidbody>().position, other.GetComponent<Rigidbody>().rotation);
            gameController.GameOver();
        }
        else                            //Astro Destroy
        {
            gameController.AddScore(score);
        }
        if (explosion != null)
        {
            Instantiate(explosion, this.GetComponent<Rigidbody>().position, this.GetComponent<Rigidbody>().rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
