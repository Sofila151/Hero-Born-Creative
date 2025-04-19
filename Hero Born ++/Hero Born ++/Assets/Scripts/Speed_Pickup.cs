using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Pickup : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public GameBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SpeedBoost(collision.gameObject);
            GetComponent<AudioSource>().Play();
            Destroy(this.transform.parent.gameObject ,0.05f);
            Debug.Log("Need for Speed Mode Active");
            gameManager.Items += 1;
        }
    }

    void SpeedBoost(GameObject player)
    {
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        
        if (playerBehavior != null)
        {
            playerBehavior.moveSpeed *= speedMultiplier;
        }
    }
}