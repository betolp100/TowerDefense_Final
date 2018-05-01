﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    protected static LevelManager instance=null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void QuitLevel()
    {
        Debug.Log("Game Finished");
        Application.Quit();
    } 

    public void LoadLevel(string name)
    {
        Debug.Log("1_2");
        SceneManager.LoadScene(name);
        Debug.Log("1_3");
    }

    public void LoadNextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}