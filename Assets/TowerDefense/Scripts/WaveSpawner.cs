using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    private Image bossPanel;
    private Text bossText;

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
    public Text waveIndexText;
    public Text waveCountDownText;
    public Text lifeText;
    public Text moneyText;
    public Text scoreText;

    private int round = 0;

    private void Start()
    {
        stop = false;
        enemyDeathLimitperPhase = GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock *5*5+15;
        bossLimit = enemyDeathLimitperPhase - 2 - GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock* GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock;
        enemyCounter = 0;
        enemyDeathCounter = 0;
        Debug.Log(enemyDeathLimitperPhase);
        enemies = new List<Transform>();
        waveStart=GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex;
        bossPanel = GameObject.Find("BossPanel").GetComponent<Image>();
        bossText = GameObject.Find("Sparkle").GetComponent<Text>();
        bossPanel.enabled = false;
        bossText.enabled = false;
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
        
        waveIndexText.text = GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex.ToString();
        lifeText.text = PlayerStats.life.ToString();
        moneyText.text = PlayerStats.money.ToString();
        scoreText.text = PlayerStats.score.ToString();

    }

    IEnumerator ChangeScene()
    {
        bossPanel.enabled = false;
        bossText.enabled = false;
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
                bossText.text = "Boss Wave Arrived!";
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
        bossPanel.enabled = true;
        bossText.enabled = true;
        yield return new WaitForSeconds(.3f);
        bossPanel.enabled = false;
        bossText.enabled = false;
        yield return new WaitForSeconds(.3f);
        bossPanel.enabled = true;
        bossText.enabled = true;
        yield return new WaitForSeconds(.3f);
        bossPanel.enabled = false;
        bossText.enabled = false;
        yield return new WaitForSeconds(.3f);
        bossPanel.enabled = true;
        bossText.enabled = true;
        yield return new WaitForSeconds(.3f);
        bossPanel.enabled = false;
        bossText.enabled = false;
        yield return new WaitForSeconds(.3f);
        bossPanel.enabled = true;
        bossText.enabled = true;
    }
}
