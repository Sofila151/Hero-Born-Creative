using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour 
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
             Debug.Log("Item collected!");
            gameManager.Items += 1;
         }
     }
 }