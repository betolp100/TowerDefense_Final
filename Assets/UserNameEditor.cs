using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserNameEditor : MonoBehaviour {

    public int pointer = 0;
    public string[] name = new string[5];
    private string username;

    public int score;
    public GameObject panel;
    public Button SSButton;

    public Text usernameUI, endUsername;

	void Start ()
    {
        usernameUI.text = "      ";
        score=PlayerStats.score;
        name[0] = " ";
        name[1] = " ";
        name[2] = " ";
        name[3] = " ";
        name[4] = " ";

        endUsername.gameObject.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void AddLetterToUserName(string letter)
    {
        if (pointer <5) 
        {
            Debug.Log("Letra presionada: " + letter);
            name[pointer] = letter;
            pointer++;
            ShowUserName();
        }
        else
        {
            Debug.Log("No puedes poner mas de 5 letras.");
        }
    }

    public void RemoveLetterFromUsername()
    {
        if (pointer >= 0)
        {
            Debug.Log("Eliminando letra");
            name[pointer] = " ";
            pointer--;
            ShowUserName();
        }
        else
        {
            Debug.Log("El nombre ya esta vacío.");
        }
    }

    public void EraseUserName()
    {
        Debug.Log("Borrando Nombre");
        name[0] = " " ;
        name[1] = " ";
        name[2] = " ";
        name[3] = " ";
        name[4] = " ";
        pointer = 0;
        ShowUserName();
    }

    private void ShowUserName()
    {
        username = name[0] + name[1] + name[2] + name[3] + name[4];
        usernameUI.text = username;
    }

    public void OK()
    {
        panel.gameObject.SetActive(false);
        endUsername.text = username;
        endUsername.gameObject.SetActive(true);
        Highscores.AddNewHighscore(username, score);
    }
    
}
