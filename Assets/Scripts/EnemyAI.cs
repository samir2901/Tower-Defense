using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wayPointIndex;
    // Start is called before the first frame update
    void Start()
    {        
        Timer timer = GameObject.Find("GameManager").GetComponent<Timer>();
        if (timer.timer <= 300)
        {
            speed = speed + 2.3f;
        }
        else if(timer.timer <= 200)
        {
            speed = speed + 4.5f;
        }
        else if (timer.timer <= 200)
        {
            speed = speed + 5f;
        }
        else if(timer.timer <= 100)
        {
            speed = speed + 7f;
        }
        wayPointIndex = 0;
        target = Waypoints.wayPoints[wayPointIndex];
        //Debug.Log(this.name + " : " + "speed = " + speed);
    }

    // Update is called once per frame
    void Update()
    {        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        if (Vector3.Distance(transform.position, target.position)<=0.1f)
        {
            if (wayPointIndex < Waypoints.wayPoints.Length - 1)
            {
                wayPointIndex++;
                target = Waypoints.wayPoints[wayPointIndex];
            }
            else
            {
                DamagePlayer();
                Destroy(gameObject);
            }
        }
    }

    void DamagePlayer()
    {
        PlayerStats.health -= 5;
        if (PlayerStats.money>0)
        {
            PlayerStats.money -= 10;
        }        
    }
}
