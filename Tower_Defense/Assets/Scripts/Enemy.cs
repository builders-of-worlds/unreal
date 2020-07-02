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

    //turret lőtávolsága

    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firepoint;

    [Header("Unity Setup Fields")]

    //cimke az ellenséges objektumokhoz
    public string enemyTag = "Player";

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

