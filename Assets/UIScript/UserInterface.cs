using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class UserInterface : MonoBehaviour
{
    GameObject ScorePanel;
    private void Start()
    {
        ScorePanel = GameObject.FindGameObjectWithTag("PanelLoad");
    }
    public void Play()
    {        
        SceneManager.LoadScene("GameScene");
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Score()
    {
        ScorePanel.SetActive(true);
    }
    public void Settings()
    {
    }
   
    public void Exit()
    {
        Application.Quit();
    }
}
