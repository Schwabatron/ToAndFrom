using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Pressed Button");
        SceneManager.LoadSceneAsync("Boat-Scene");
    }

     public void Credits()
    {
        Debug.Log("Pressed Button");
        SceneManager.LoadSceneAsync("Credits");
    }

     public void Settings()
    {
        Debug.Log("Pressed Button");
        SceneManager.LoadSceneAsync("Settings");
    }
        public void Home()
    {
        Debug.Log("Pressed Button");
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
