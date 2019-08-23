using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject gameDataPrefab;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(gameDataPrefab);
            SceneManager.LoadScene("WorldScene");
        }

    }
}
