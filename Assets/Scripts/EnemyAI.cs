using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Transform target;
    private int wayPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        wayPointIndex = 0;
        target = Waypoints.wayPoints[wayPointIndex];
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
                Destroy(gameObject);
            }
        }
    }
}
