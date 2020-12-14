using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void GoToHelp()
    {
        SceneManager.LoadScene("HelpScene");
    }
    
    public void GoToSetting()
    {
        SceneManager.LoadScene("SettingScene");
    }
    
    public void GoToScore()
    {
        SceneManager.LoadScene("ScoreScene");
    }
    
}
