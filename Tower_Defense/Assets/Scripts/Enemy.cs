using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    // lõtávolsága
    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firepoint;
    public string playerTag = "Player";
    //referencia a célponthoz
    public Transform target;

    public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	private float health;

	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	void Start ()
	{
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("UpdateShoot", 0f, 0.1f);
        speed = startSpeed;
		health = startHealth;
        
    }

	public void TakeDamage (float amount)
	{
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

    //enemy aktuális célpontját frissítõ metódus
    void UpdateTarget()
    {
        //összes Player cimkés game object összegyûjtése egy tömbbe 
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        //legközelebbi ellenfél távolsága = végtelen
        float shortestDistanceToPlayer = Mathf.Infinity;

        //segédváltozó az aktuális legközelebbi ellenfélhez
        GameObject nearestPlayer = null;

        //bejárjuk a player tömböt
        foreach (GameObject player in players)
        {
            //aktuális elem távolséga a enemytõl
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

        //ha van legközelebbi ellenséges game object és lõtávon belül van akkor
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
