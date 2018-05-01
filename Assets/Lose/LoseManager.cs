using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{   
    public Text scoreUI;
    private int score;

    public GameObject panel;
    public Button SSButton;

    public bool isPanelOpen;

    private void Start()
    {
        score = PlayerStats.score;
        isPanelOpen = false;
        scoreUI.text = PlayerStats.score.ToString();
        

        panel.gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Start");
    }


    public void EndGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().QuitLevel();
    }

    public void SaveScore()
    {
        SSButton.gameObject.SetActive(false);
        LoadKeyboard();
    }

    private void LoadKeyboard()
    {
        Debug.Log("APARECER TECLADO");
        panel.gameObject.SetActive(true);


    }
}
