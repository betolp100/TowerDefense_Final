using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public static int score;

    public static int money;
    public int startmoney = 1000;
    public static int life;
    public int startlife = 3;
    public int waveIndex;
    public int waveIndexStart;
    public int enemyCounter;
    private int enemyStartCounter=0;
    public int waveBlock;
    private int waveBlockStart = 0;

    protected static PlayerStats instance = null;

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

    void Start()
        {
            score = 0;
            money = startmoney;
            life = startlife;
            waveIndex = waveIndexStart;
            enemyCounter = enemyStartCounter;
            waveBlock = waveBlockStart;
        }



}
