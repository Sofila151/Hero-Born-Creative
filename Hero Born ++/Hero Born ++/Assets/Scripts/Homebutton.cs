using UnityEngine;
using UnityEngine.SceneManagement;

public class Homebutton : MonoBehaviour
{
    public void Playagain()
    {
        SceneManager.LoadScene("Game");
}
}