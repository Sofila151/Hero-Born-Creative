using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour 
{
    public Text healthText;
    public Text itemsText;
    public Text messageText;
    public GameObject winScreen;
    public GameObject lossScreen;
    public Button restartButton;
    public Button creditsButton;

    private int _itemsCollected = 0;
    private int _playerHP = 2;
    public int maxItems = 4;

    private bool showWinScreen = false;
    private bool showLossScreen = false;

    private string labeltext = "Collect all 4 items to win!";

    public int Items
    {
        get { return _itemsCollected; }
        set 
        { 
            _itemsCollected = value; 
            if (itemsText != null) 
                itemsText.text = "Items Collected: " + _itemsCollected;

            if (_itemsCollected >= maxItems)
            {
                labeltext = "You've found all the items!";
                showWinScreen = true;

                if (winScreen != null) 
                    winScreen.SetActive(true);

                if (creditsButton != null) 
                creditsButton.gameObject.SetActive(true); 
                Time.timeScale = 0f;
            }
            else
            {
                labeltext = "Power up found, way to go!";
            }
            
            if (messageText != null)
                messageText.text = labeltext;
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (healthText != null) 
                healthText.text = "Player Health: " + _playerHP;

            if (_playerHP <= 0)
            {
                labeltext = "You want another life with that?";
                showLossScreen = true;

                if (lossScreen != null) 
                    lossScreen.SetActive(true);

                if (restartButton != null) 
                    restartButton.gameObject.SetActive(true); 
                Time.timeScale = 0f;
            }
            else
            {
                labeltext = "Ouch... that’s gotta hurt.";
            }

            if (messageText != null)
                messageText.text = labeltext;

            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void RestartLevel()  
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToCredits()
    {
        Time.timeScale = 1.0f; 
        SceneManager.LoadScene("Credits");
    }
}