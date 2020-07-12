using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    // l�t�vols�ga
    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firepoint;
    public string playerTag = "Player";
    //referencia a c�lponthoz
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

    //enemy aktu�lis c�lpontj�t friss�t� met�dus
    void UpdateTarget()
    {
        //�sszes Player cimk�s game object �sszegy�jt�se egy t�mbbe 
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        //legk�zelebbi ellenf�l t�vols�ga = v�gtelen
        float shortestDistanceToPlayer = Mathf.Infinity;

        //seg�dv�ltoz� az aktu�lis legk�zelebbi ellenf�lhez
        GameObject nearestPlayer = null;

        //bej�rjuk a player t�mb�t
        foreach (GameObject player in players)
        {
            //aktu�lis elem t�vols�ga a enemyt�l
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            //ha az aktu�lis elem t�vols�ga kisebb mint az eddigi legkisebb akkor
            if (distanceToPlayer < shortestDistanceToPlayer)
            {
                //�t�ll�tjuk erre az �rt�kre a legk�zelebbi t�vot
                shortestDistanceToPlayer = distanceToPlayer;
                //be�ll�tjuk a seg�dv�ltoz�t az aktu�lis elemre 
                nearestPlayer = player;
            }
        }

        //ha van legk�zelebbi ellens�ges game object �s l�t�von bel�l van akkor
        if (nearestPlayer != null && shortestDistanceToPlayer <= range)
        {
            // a target adattagot be�ll�tjuk erre a referenci�ra
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
