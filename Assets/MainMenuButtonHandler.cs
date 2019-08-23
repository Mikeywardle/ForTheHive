using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{

    [SerializeField] private string newGameScene;

    public void CreateNewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void LoadGame()
    {
        Debug.Log("Roading");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
