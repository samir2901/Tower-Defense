using UnityEngine;

public class Turret : MonoBehaviour
{    
    [SerializeField] private Transform axisToRotate;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ParticleSystem shootParticles; 
    [Header("Turret Settings")]
    [SerializeField] private float range = 15f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float fireRate = 6f;
    [SerializeField] private int damageAmount = 1;
    

    private float nextTimeToFire = 0f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {        
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy!=null && minDist < range)
        {
            target = nearestEnemy.transform;
        }        
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }        


        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
        }
        
    }

    private void Shoot()
    {
        Vector3 dir = (target.position - axisToRotate.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(axisToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        axisToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        shootParticles.Play();
        GameObject bulletG = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletG.GetComponent<Bullet>();
        bullet.damageAmount = damageAmount;
        bullet.target = target;

        Debug.DrawRay(axisToRotate.position, dir, Color.green);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
