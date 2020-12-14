using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour
{
    public void GoToCaraMain()
    {
        SceneManager.LoadScene("CaraMainScene");
    }
    
    public void GoToJenisSampah()
    {
        SceneManager.LoadScene("JenisSampahScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
