using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class SavedGame : MonoBehaviour
{
}
/*public static class SavedGame
{

    public static void SaveTurrets(Turret turret)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/turrets.saves", FileMode.Create);

        TurretsData data = new TurretsData(turret);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static GameObject[] LoadTurrets()
    {
        if (File.Exists(Application.persistentDataPath + "/turrets.saves"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/turrets.saves", FileMode.Open);
            TurretsData data = bf.Deserialize(stream) as TurretsData;

            stream.Close();
            return data.turrets;

        }
        else
        {
            Debug.Log("File does not exist");
            return new GameObject[1000];
        }
    }

}

[Serializable]
public class TurretsData
{
    public GameObject[] turrets;

    
}



    //[HideInInspector]
    /*public List<GameObject> turretsInMap;
    protected static SavedGame instance = null;

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

    private void Start()
    {
        turretsInMap = new List<GameObject>();
        FirstNull();
        
    }

    void FirstNull()
    {
        turretsInMap.Add(null);
    }
    public void Test() { Debug.Log("HOLAAA PROBANDO"); }

    public void AddToTIMList(GameObject turret)
    {
        turretsInMap.Add(turret);
        
        
    }*/
    

