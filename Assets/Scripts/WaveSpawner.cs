using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float timeBtwWaves = 2f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;    
    private float currentTime;
    private float waveNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeBtwWaves;        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0f)
        {
            StartCoroutine(SpawnWave());
            currentTime = timeBtwWaves;
        }
        currentTime = currentTime - Time.deltaTime;        
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();            
            yield return new WaitForSeconds(2f);
        }        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}