using UnityEngine;
using UnityEngine.UI;

abstract public class Enemy : MonoBehaviour
{


    [Header("Unity Stuff")]
    public Image healthBar;

    public float speed;
    public float hp = 100f;

    private Transform target;
    private int wavepointIndex = 0;

    public Image HealthBar { get => healthBar; set => healthBar = value; }

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
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
        target = Waypoints.points[wavepointIndex];
    }
}

