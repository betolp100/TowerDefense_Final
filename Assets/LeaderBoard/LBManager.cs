using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LBManager : MonoBehaviour
{
    public void ReturnToMenu()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Start");
    }
}
