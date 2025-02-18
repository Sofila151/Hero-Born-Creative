using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour 
 {
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public string labeltext = "Collect all power ups then capture the red capsule";
    public int maxItems = 4;

    private int _itemsCollected = 0;
    public int Items
     {
         get { return _itemsCollected; }
         set { 
             _itemsCollected = value; 

            if(_itemsCollected >= maxItems)

            {
                labeltext = "You've found all the items!";

                showWinScreen = true;

                Time.timeScale = 0f;
            }
            else
            {
                labeltext = "Power up found way to go!";
            }
         }
      }
     
    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;

            if (_playerHP <= 0)
            {
                labeltext = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labeltext = "Ouch... that’s gotta hurt.";
            }

            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labeltext);

        if (showWinScreen && GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You Won!"))
        {
            RestartLevel();
        }

        if (showLossScreen && GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
        {
            RestartLevel();
        }
    }
}