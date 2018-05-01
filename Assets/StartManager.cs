using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{

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