using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int startHealth = 10;

    private void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            PlayerStats.money += 10;
            Destroy(gameObject);
        }
    }    
}
