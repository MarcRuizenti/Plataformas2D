using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void ClickBotton(GameObject botton)
    {
        botton.SetActive(false);
    }

    public void ResetScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Return()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        
    }
}
