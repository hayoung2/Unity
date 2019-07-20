using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltContact : MonoBehaviour
{
    public GameObject explostion;
    public GameObject playerExplostion;
    public int scoreValue;//점수 
    private GameController gameController;//참조할것

    private void Awake()
    {
        //해당 객체 찾아라(Find)  느림 별로  
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            Destroy(gameObject);

        if (other.tag == "Enemy") return;


        if (explostion != null)
        {
            Instantiate(explostion, transform.position, other.transform.rotation);
        }


        if (other.tag == "Player")
        {
            Instantiate(playerExplostion, transform.position, other.transform.rotation);
            gameController.GameOver();
        }


        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
