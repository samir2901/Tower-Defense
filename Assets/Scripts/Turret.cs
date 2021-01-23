using UnityEngine;

public class Turret : MonoBehaviour
{    
    [Header("General Settings")]
    [SerializeField] private Transform axisToRotate;
    [SerializeField] private Transform firePoint;    
    [SerializeField] private float range = 15f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private int damageAmount = 1;

    [Header("Use Bullet Settings (DEFAULT)")]    
    [SerializeField] private float fireRate = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ParticleSystem shootParticles;

    [Header("Use Laser Settings")]
    [SerializeField] private bool useLaser = false;
    [SerializeField] private LineRenderer laser;
    [SerializeField] private ParticleSystem laserShootEffect;
    [SerializeField] private ParticleSystem laserHitEffect;



    private float nextTimeToFire = 0f;
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        if (useLaser)
        {
            laserShootEffect.transform.position = firePoint.position;
        }        
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
        if (nearestEnemy!=null && minDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (laser.enabled)
                {
                    laser.enabled = false;
                    laserShootEffect.Stop();
                    laserHitEffect.Stop();
                }
            }
            return;
        }

        LockOnTarget();

        if (!useLaser)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);
                Shoot();
            }
        }
        else
        {
            ShootLaser();
        }
        
    }

    void ShootLaser()
    {
        if (!laser.enabled)
        {
            laser.enabled = true;
            laserShootEffect.Play();
            laserHitEffect.Play();            
        }
        laser.SetPosition(0, firePoint.position);
        laser.SetPosition(1, target.position);
        laserHitEffect.transform.position = target.position;
        target.GetComponent<EnemyHealth>().health -= damageAmount;
    }

    void LockOnTarget()
    {
        Vector3 dir = (target.position - axisToRotate.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(axisToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        axisToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void Shoot()
    {        
        
        shootParticles.Play();
        GameObject bulletG = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletG.GetComponent<Bullet>();
        bullet.damageAmount = damageAmount;
        bullet.target = target;

        //Debug.DrawRay(axisToRotate.position, dir, Color.green);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
