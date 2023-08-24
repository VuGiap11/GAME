using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startGame;
    public void StartGame(int indexScene)
    {
       SceneManager.LoadScene(indexScene);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
