using UnityEngine;

public class Enemy : MonoBehaviour {
    private int wavepointIndex = 0;
    public float speed;
    private Transform target;
    public Transform rotationPoint;
    public float turnSpeed;
    public float health;
    private bool imBoss;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }   

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (Vector3.Distance(transform.position, target.position) <= .2f)
        {
            GetNextWaypoint();
        }
    }
    
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>().enemyDeathCounter++;
            Debug.Log("Enemigo llego a la base ");
            PlayerStats.life--;
            if (PlayerStats.life <= 0)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Lose");
            }
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    void Die()
    {
        if (imBoss == false)
        {
            PlayerStats.score += 100;
        }else
        if (imBoss==true)
        {
            PlayerStats.score += 2000;
        }

        GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>().enemies.Remove(transform);
        Destroy(gameObject);
    }

    public void IamTheBoss(bool state)
    {
        imBoss = state;
    }
}
