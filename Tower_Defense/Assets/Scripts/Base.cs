using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    
    public float speed;
    public float hp = 100f;

    private Transform target;
    private int wavepoint_baseIndex = 0;

    //Időzítés

    

    void Start()
    {
        target = Waypoints_Base.points[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint_Base();
            
        }
        


    }

    public virtual void TakeDamage(float amount)
    {
    }

    void GetNextWaypoint_Base()
    {

        if (wavepoint_baseIndex >= Waypoints_Base.points.Length - 1)
        {
            Debug.Log("Győztél!");
            //Destroy(gameObject);
            return;
        }
        wavepoint_baseIndex++;
        target = Waypoints_Base.points[wavepoint_baseIndex];
    }
}
