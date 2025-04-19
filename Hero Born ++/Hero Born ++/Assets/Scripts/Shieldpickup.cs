using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldpickup : MonoBehaviour
{
    public GameBehavior gameManager;
    public GameObject shieldObject;
    private bool isShieldActive = false;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && !isShieldActive)
        {
            ShowShield(collision.gameObject);
            GetComponent<AudioSource>().Play();
            Destroy(this.transform.parent.gameObject ,0.05f);
            Debug.Log("Shield activated!");
            gameManager.Items += 1;
        }
    }

    void ShowShield(GameObject player)
    {
        Transform shieldTransform = player.transform.Find("Shield");

        if (shieldTransform != null && !isShieldActive)
        {
            shieldTransform.gameObject.SetActive(true);  
            isShieldActive = true; 
        }
    }
}