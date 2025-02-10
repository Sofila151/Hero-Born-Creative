using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Pickup : MonoBehaviour
{
    public float speedBoostAmount = 2f;
    public GameBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            MakePlayerFaster(collision.gameObject);
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Need for Speed Mode Active");
            gameManager.Items += 1;
        }
    }

    void MakePlayerFaster(GameObject player)
    {
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        
        if (playerBehavior != null)
        {
            playerBehavior.moveSpeed *= speedBoostAmount;
        }
    }
}
