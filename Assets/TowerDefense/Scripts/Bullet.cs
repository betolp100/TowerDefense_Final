using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float bulletSpeed = 5f;
    public int damage = 25;
    public GameObject impactEffect;
    public float explosionRange = 10f;
      

    public void Seek(Transform _target)
        {
            target = _target;
        }


    // Update is called once per frame
    
    void Update ()
        {
        if (target == null)
            {
                Destroy(gameObject);
                return;
            }

        
        Vector3 dir = target.position - transform.position;

            float distanceThisFrame = bulletSpeed * Time.deltaTime;
        
            if (dir.magnitude <= distanceThisFrame)
                {
                    HitTarget();
                    return;
                }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);
	    }

    void HitTarget()
    {
        GameObject explosionEffect_01 = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(explosionEffect_01, 5f);

        if (explosionRange > 0f)
        {
            Explosion();

        }

        Destroy(gameObject);
    }

    void Explosion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);
            foreach (Collider collider in colliders)
                {
                    if (collider.tag == "Enemy"|| collider.tag == "Boss")
                        {
                            Damage(collider.transform);
                        }
                }
        }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, explosionRange);
        }

}
