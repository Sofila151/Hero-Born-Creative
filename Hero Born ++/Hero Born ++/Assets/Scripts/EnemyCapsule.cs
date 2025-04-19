using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapsule : MonoBehaviour
 {
     public GameBehavior gameManager;
 
     void Start()
     {              
            gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
     }
     void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.name == "Player")
         {
            GetComponent<AudioSource>().Play();
             Destroy(this.transform.parent.gameObject ,0.05f);
             Debug.Log("Enemy Capsule Secured!");
             gameManager.Items += 1;
         }
     }
 }