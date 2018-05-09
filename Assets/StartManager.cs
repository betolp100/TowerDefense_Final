using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public void Start()
    {
        if (GameObject.Find("UserData") != null)
        {
            PlayerStats.score = 0;
            PlayerStats.money = 150;
            GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock = 0;
            PlayerStats.life = 3;
            GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex = 0;
            GameObject.Find("UserData").GetComponent<PlayerStats>().enemyCounter = 0;
            Debug.Log("REINICIANDO");
        }

    }

    public void PlayGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("game");
    }

    public void LeaderBoard()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("LeaderBoard");
    }


    public void EndGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().QuitLevel();
    }
}