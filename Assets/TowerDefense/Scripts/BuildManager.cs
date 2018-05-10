using System;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    
    public GameObject savedGame;
    public static BuildManager instance;
    public GameObject Turret_01_Prefab;
    public GameObject Turret_02_Prefab;
    public GameObject Turret_03_Prefab;
    private TurretBluePrint turretToBuild;
    public GameObject buildEffect;
    public Vector3 offset = new Vector3 (0,0,0);

  
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    
    public bool CanBuild { get { return turretToBuild != null; } } //PROPERTY CHECK IF THE VARIABLE IS EQUAL TO NULL ONLY.
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
        {
        if (PlayerStats.money < turretToBuild.cost)
            {
                Debug.Log("Not enough money");
                
                return;
            }
        PlayerStats.money -= turretToBuild.cost;
        Debug.Log("Turret Build. Money left: "+ PlayerStats.money);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition()+offset, Quaternion.identity); //Quaternion identity dont rotate at all.
        

        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition()+offset, Quaternion.identity); 
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
        {
            turretToBuild = turret;
        }

    

}
