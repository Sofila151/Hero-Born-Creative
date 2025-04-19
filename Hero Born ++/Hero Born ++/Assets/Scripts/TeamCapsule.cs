using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCapsule : MonoBehaviour
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
             Destroy(this.transform.parent.gameObject, .05f);
             Debug.Log("Team Capsule Secured, defend");
             gameManager.Items += 1;
         }
     }
 }