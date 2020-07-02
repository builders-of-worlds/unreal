using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //counter


    //Enemy prefabok bekérése
    public Transform enemyPrefab;
    public Transform enemy_2Prefab;
    //Enemy létrehozásának a helye
    public Transform spawnPoint;
    //Visszaszámlálás indítása, és a kiíráshoz szükséges txt bekérése
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public Text waveCountdownText;
    private int waveIndex = 0;

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


    //Visszaszámlálás
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    //Enemy létrehozása a játéktérben
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            if (i % 2 == 0)
            {
                SpawnEnemy();
            }
            else
            {
                SpawnEnemy_2();
            }

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Hullám indítása!");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

    void SpawnEnemy_2()
    {
        Instantiate(enemy_2Prefab, spawnPoint.position, spawnPoint.rotation);
    }

}
