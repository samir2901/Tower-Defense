using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed=20f;
    [SerializeField] private GameObject particleFXPrefab;
    [HideInInspector]
    public int damageAmount;
    public Transform target;    
    
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * bulletSpeed);
        if (target==null)
        {
            Destroy(gameObject);
            return;           
        }
        Vector3 dir = (target.position - transform.position);
        float distance = bulletSpeed * Time.deltaTime;
        if (dir.magnitude <= distance)
        {
            EnemyHealth enemyHealth = target.gameObject.GetComponent<EnemyHealth>();
            GameObject particleFX = Instantiate(particleFXPrefab, transform.position, transform.rotation);
            Destroy(particleFX, 5f);
            enemyHealth.health -= damageAmount;
            Destroy(gameObject);
        }        
        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(target);

    }
    

}
