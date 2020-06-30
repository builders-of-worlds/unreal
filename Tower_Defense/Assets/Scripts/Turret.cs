using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    /*
    Turret forgatása nélküli verzió
   */

    //referencia a célponthoz
    public Transform target;

    [Header("Attributes")]

    //turret lőtávolsága
    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firepoint;

    [Header("Unity Setup Fields")]

    //cimke az ellenséges objektumokhoz
    public string enemyTag = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    //turret aktuális célpontját frissítő metódus
    void UpdateTarget()
    {
        //összes Enemy cimkés game object összegyűjtése egy tömbbe 
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //legközelebbi ellenfél távolsága = végtelen
        float shortestDistanceToEnemy = Mathf.Infinity;

        //segédváltozó az aktuális legközelebbi ellenfélhez
        GameObject nearestEnemy = null;

        //bejárjuk az enemy tömböt
        foreach (GameObject enemy in enemies)
        {
            //aktuális elem távolséga a turrettől
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //ha az aktuális elem távolsága kisebb mint az eddigi legkisebb akkor
            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                //átállítjuk erre az értékre a legközelebbi távot
                shortestDistanceToEnemy = distanceToEnemy;
                //beállítjuk a segédváltozót az aktuális elemre 
                nearestEnemy = enemy;
            }
        }

        //ha van legközelebbi ellenséges game object és lőtávon belül van akkor
        if (nearestEnemy != null && shortestDistanceToEnemy <= range)
        {
            // a target adattagot beállítjuk erre a referenciára
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
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



    //kiválasztott turret lötávolságát jeleníti meg, scene módban
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}
