using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    /*private Image bossPanel;
    private Text bossText;
    */
    // [HideInInspector]
    public List <Transform> enemies;

    public Transform bossPrefab;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Vector3 offset;

    private bool making = false;
    private bool changeScene = false;
    public float timeBetweenWaves = 5f;
    private float countDown = 3f;
    public int enemyDeathCounter;
    private int enemyDeathLimitperPhase;
    public int bossLimit;
    public int enemyCounter;
    private int waveStart;

    private bool stop;

    private int round = 0;

    //fETCHING PANELS
    public GameObject bossPanel1, bossPanel2, roundPanel, ScorePanel, healthPanel, MoneyPanel;

    
    private void Start()
    {
        FetchButtonsAndTexts();


        stop = false;
        enemyDeathLimitperPhase = GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock *5*5+15;
        bossLimit = enemyDeathLimitperPhase - 2 - GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock* GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock;
        enemyCounter = 0;
        enemyDeathCounter = 0;
        Debug.Log(enemyDeathLimitperPhase);
        enemies = new List<Transform>();
        waveStart=GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex;
        bossPanel2.SetActive(false);
        bossPanel1.SetActive(false);

    }

    void Update()
    {

        if (countDown <= 0 && stop == false && making == false)
        {
            StartCoroutine(SpawnBlock(round));
            countDown = timeBetweenWaves;
        }
        
        if (waveStart != GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex&& stop==true && enemies.Count==0)
        {
                Debug.Log("Cambiando de juego");
                //changeScene = true;
                StartCoroutine(ChangeScene());
            }
        


        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        
        roundPanel.GetComponent<Text>().text = GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();
        healthPanel.GetComponent<Text>().text = PlayerStats.life.ToString();
        MoneyPanel.GetComponent<Text>().text = PlayerStats.money.ToString();
        ScorePanel.GetComponent<Text>().text = PlayerStats.score.ToString();

    }

    public void FetchButtonsAndTexts()
    {
        bossPanel1 = GameObject.Find("BossPanel");
        bossPanel2 = GameObject.Find("Sparkle");
        ScorePanel = GameObject.Find("Score");
        roundPanel = GameObject.Find("Round");
        healthPanel = GameObject.Find("health");
        MoneyPanel = GameObject.Find("Money");
        
    }

    IEnumerator ChangeScene()
    {
        bossPanel2.SetActive(false);
        yield return new WaitForSeconds(3f);
        
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Ask");
        
    }

    IEnumerator SpawnBlock(int i)
    {

        switch (i)
        {
            case 0:
                Debug.Log("caso0");
                making = true;
                for (int j = 0; j <= GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex; j++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.3f);

                }
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex++;
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();

                making = false;
                round++;
                break;
            case 1:
                Debug.Log("cas01");
                making = true;
                yield return new WaitForSeconds(timeBetweenWaves);
                    for (int j = 0; j <= GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex; j++)
                    {
                        SpawnEnemy();
                        yield return new WaitForSeconds(.3f);
                    }
                    GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex++;
                    GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();
                round++;
                making = false;
                break;
            case 2:
                Debug.Log("caso2");
                making = true;
                yield return new WaitForSeconds(timeBetweenWaves);
                for (int j = 0; j <= GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex; j++)
                {
                        SpawnEnemy();
                        yield return new WaitForSeconds(.3f);
                }
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex++;
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();
                making = false;
                round++;
                    break;

            case 3:
                Debug.Log("caso3");
                making = true;
                yield return new WaitForSeconds(timeBetweenWaves);
                for (int j = 0; j <= GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex; j++)
                {
                        SpawnEnemy();
                        yield return new WaitForSeconds(.3f);
                }
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex++;
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();
                StartCoroutine(Sparkle());
                yield return new WaitForSeconds(1.65f);
                making = false;
                round++;

                break;

            case 4:
                Debug.Log("caso4");
                making = true;
                yield return new WaitForSeconds(timeBetweenWaves);
                bossPanel2.GetComponent<Text>().text = "Boss Wave Arrived!";
                for (int j = 0; j <= GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex; j++)
                {
                        SpawnEnemy();
                        yield return new WaitForSeconds(.2f);
                        SpawnBoss();
                        yield return new WaitForSeconds(.3f);
                }
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex++;
                GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();
                yield return new WaitForSeconds(3f);
                making = false;
                round++;
                break;
            default:
                round = 0;
                stop = true;
                break;
        }  
    }

    void SpawnEnemy()
        {
            bool iamBoss = false;
            Transform enemy = Instantiate(enemyPrefab, spawnPoint.position + offset, spawnPoint.rotation) as Transform;
            enemy.gameObject.GetComponent<Enemy>().IamTheBoss(iamBoss);
            enemies.Add(enemy);
        }

    void SpawnBoss()
    {
        bool iamBoss = true;
        Transform boss = Instantiate(bossPrefab, spawnPoint.position + offset, spawnPoint.rotation) as Transform;
        boss.gameObject.GetComponent<Enemy>().IamTheBoss(iamBoss);
        enemies.Add(boss);
    }

    IEnumerator Sparkle()
    {
        bossPanel2.SetActive(true);
        yield return new WaitForSeconds(.3f);
        bossPanel2.SetActive(false);
        yield return new WaitForSeconds(.3f);
        bossPanel2.SetActive(true);
        yield return new WaitForSeconds(.3f);
        bossPanel2.SetActive(false);
        yield return new WaitForSeconds(.3f);
        bossPanel2.SetActive(true);
        yield return new WaitForSeconds(.3f);
        bossPanel2.SetActive(false);
        yield return new WaitForSeconds(.3f);
        bossPanel2.SetActive(true);
    }
}
