using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWING, WATTING, COUNTING };

    [System.Serializable]
    public class Wave
    {

        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {

        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.WATTING)
        {

            //check enemy 
            if (!EnemyIsAlive())
            {

                //begin a new round
                Debug.Log("wave complete");
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {

            if (state != SpawnState.SPAWING)
            {

                StartCoroutine(SpawnWave(waves[nextWave]));

            }

        }
        else
        {

            waveCountdown -= Time.deltaTime;

        }



    }

    //
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {

                return false;

            }
        }

        return true;

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("spawn enemy" + _enemy.name);
        state = SpawnState.SPAWING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WATTING;

        yield break;

    }

    void SpawnEnemy(Transform _enemy)
    {

        //spawn enemy
        Debug.Log("spawn enemy" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);

    }

}
