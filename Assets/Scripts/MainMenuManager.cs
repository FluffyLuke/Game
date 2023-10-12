using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void exit()
    {
        Application.Quit(); 
    }

    public void play()
    {
        SceneManager.LoadScene("Game");
    } 
}
