using UnityEngine;
using UnityEngine.UI;

abstract public class Enemy : MonoBehaviour
{

    private static int idCounter = -1;

    private int objectId;
    public int ObjectId { get { return this.objectId; } }


    [Header("Unity Stuff")]
    public Image HealthBar;

    public float speed;
    public float hp = 100f;

    private Transform route;
    private int wavepointIndex = 0;

    //public Image HealthBar { get => healthBar; set => healthBar = value; }

    public Enemy()
    {
        idCounter++;
        this.objectId = idCounter;
    }

    void Start()
    {

        Debug.Log("#ObjectID: " + this.objectId);
       
        route = Waypoints.points[0];
    }

    void Update()
    {
        Vector2 dir = route.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, route.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    public virtual void TakeDamage(float amount)
    {
    }

    void GetNextWaypoint()
    {

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        route = Waypoints.points[wavepointIndex];
    }
}

