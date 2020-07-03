using UnityEngine;
using UnityEngine.UI;



abstract public class Enemy : MonoBehaviour
{

    private static int idCounter = -1;

    private int objectId;
    public int ObjectId { get { return this.objectId; } }

    //referencia a célponthoz
    public Transform target;

    //public HealthBar HealthBar { get; }

    //[Header("Unity Stuff")]
    

    public float speed;
    public float hp = 100f;

    private Transform route;
    private int wavepointIndex = 0;

    // lőtávolsága
    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firepoint;

    [Header("Unity Setup Fields")]

    //cimke az ellenséges objektumokhoz
    public string playerTag = "Player";

    //public Image HealthBar { get => healthBar; set => healthBar = value; }

    public Enemy()
    {
        idCounter++;
        this.objectId = idCounter;
    }

    void Start()
    {

        HealthBar = new HealthBar();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("UpdateShoot", 0f, 0.1f);

        Debug.Log("#ObjectID: " + this.objectId);
       
        route = Waypoints.points[0];
    }

    //enemy aktuális célpontját frissítő metódus
    void UpdateTarget()
    {
        //összes Player cimkés game object összegyűjtése egy tömbbe 
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        //legközelebbi ellenfél távolsága = végtelen
        float shortestDistanceToPlayer = Mathf.Infinity;

        //segédváltozó az aktuális legközelebbi ellenfélhez
        GameObject nearestPlayer = null;

        //bejárjuk a player tömböt
        foreach (GameObject player in players)
        {
            //aktuális elem távolséga a enemytől
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            //ha az aktuális elem távolsága kisebb mint az eddigi legkisebb akkor
            if (distanceToPlayer < shortestDistanceToPlayer)
            {
                //átállítjuk erre az értékre a legközelebbi távot
                shortestDistanceToPlayer = distanceToPlayer;
                //beállítjuk a segédváltozót az aktuális elemre 
                nearestPlayer = player;
            }
        }

        //ha van legközelebbi ellenséges game object és lőtávon belül van akkor
        if (nearestPlayer != null && shortestDistanceToPlayer <= range)
        {
            // a target adattagot beállítjuk erre a referenciára
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }

    void UpdateShoot()
    {

        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();

            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

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

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);

        Bulet bullet = bulletGO.GetComponent<Bulet>();

        if (bullet != null)
        {
            bullet.Seek(this.target);
        }

        Debug.Log("Shooot!");
    }
}

