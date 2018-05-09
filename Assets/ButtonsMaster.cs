using UnityEngine;

public class ButtonsMaster : MonoBehaviour {

    public GameObject exitpanel, endGame, returnToMenu, menuPanel;

    public GameObject[] turrets;

    void Start ()
    {
        FetchButtons();
        
        exitpanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    public void OpenExitPanel()
    {
        exitpanel.SetActive(true);
        endGame.SetActive(false);
        returnToMenu.SetActive(false);
    }

    public void CloseExitPanel()
    {
        exitpanel.SetActive(false);
        endGame.SetActive(true);
        returnToMenu.SetActive(true);
    }

    public void OpenMenuPanel()
    {
       
        

        menuPanel.SetActive(true);
        endGame.SetActive(false);
        returnToMenu.SetActive(false);
    }

    public void CloseMenuPanel()
    {
        menuPanel.SetActive(false);
        endGame.SetActive(true);
        returnToMenu.SetActive(true);
    }

    public void FetchButtons()
    {
        endGame = GameObject.Find("ExitGame");
        exitpanel = GameObject.Find("EndingGame");
        returnToMenu = GameObject.Find("Return");
        menuPanel = GameObject.Find("ReturningToMenu");
        Debug.Log("INICIANDO FETCHING");
    }

    public void ReturnToMainMenu()
    {
        turrets = GameObject.FindGameObjectsWithTag("Turret");

        foreach (GameObject turret in turrets)
        {
            Destroy(turret);
        }

        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Start");
    }

    public void ExitGame()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().QuitLevel();
    }

    public void HidePanels()
    {
        exitpanel.SetActive(false);
        menuPanel.SetActive(false);
    }

}
