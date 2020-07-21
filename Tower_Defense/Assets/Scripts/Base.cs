using UnityEngine;

public class Base : MonoBehaviour
{
    
    public float speed;
    public float hp = 100f;

    private Transform target;
    private int wavepoint_baseIndex = 0;

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

    void GetNextWaypoint_Base()
    {

        if (wavepoint_baseIndex >= Waypoints_Base.points.Length - 1)
        {
            
            return;
        }
        wavepoint_baseIndex++;
        target = Waypoints_Base.points[wavepoint_baseIndex];
    }
}
