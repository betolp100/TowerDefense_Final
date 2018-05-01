using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour {

    private Transform target;
    Scene currentScene;
    string sceneName;
    

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 2f;
    private float fireCountDown = 0f;

    [Header ("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform TorretRotate;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        DontDestroyOnLoad(gameObject);
    }


    void OnDrawGizmosSelected()
        {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        }

    void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if(distanceToEnemy< shortestDistance)
                        {
                            shortestDistance = distanceToEnemy;
                            nearestEnemy = enemy;
                        }
                }

            if (nearestEnemy != null && shortestDistance <= range)
                {
                    target = nearestEnemy.transform;

                }
            else
                {
                    target=null;
                }
            }

    void Update()
        {
            if (sceneName == "game")
            {
                gameObject.SetActive(true);
            }
            else if (sceneName == "ASK"|| sceneName == "Lose" || sceneName == "Start")
            {
                gameObject.SetActive(false);
            }


        fireCountDown -= Time.deltaTime;
            if (target == null) return;

            //Apuntamos al enemigo
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(TorretRotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
            TorretRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountDown <= 0)
                {
                    Shoot();
                    fireCountDown = 1f / fireRate;
                }
            fireCountDown -= Time.deltaTime;
    }

    void Shoot()
        {
            GameObject bulletFire = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletFire.GetComponent<Bullet>();

            if (bullet != null)
                {
                    bullet.Seek(target);
                }
        }

    /*void Start()
    {
        SaveTurret();

       
    }

    public void SaveTurret()
    {
        SavedGame.SaveTurrets(this);
    }*/

}