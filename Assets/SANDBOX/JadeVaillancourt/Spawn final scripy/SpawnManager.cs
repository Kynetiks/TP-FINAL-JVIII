using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private FindSpawnPositions findSpawnPositions;
    [SerializeField] private List<EnemyWaveData>enemyWaveDate = new List<EnemyWaveData>();
   
    [SerializeField] private float delayBeforeSpawn = 5f;


    private int currentWaveIndex = 0; // L'index de la vague courante
    private bool isSpawning = false; // Pour vérifier si les vagues sont en train de se dérouler

    // Start is called before the first frame update
    void Start()
    {
        findSpawnPositions.SpawnAmount = enemyWaveDate[0].spawnAmount;
        findSpawnPositions.StartSpawn(MRUK.Instance.GetCurrentRoom());

        Debug.Log("test");

        StartCoroutine(SpawnWaves());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

     private IEnumerator SpawnWaves()
    {
        // Attente initiale avant de commencer les vagues
        yield return new WaitForSeconds(delayBeforeSpawn);

        while (currentWaveIndex < enemyWaveDate.Count)
        {
            
            EnemyWaveData currentWave = enemyWaveDate[currentWaveIndex];
            Debug.Log("Spawning Wave " + (currentWaveIndex + 1));

            
            StartCoroutine(SpawnEnemiesInWave(currentWave));

            yield return new WaitForSeconds(currentWave.BetweenWavesDelay);

       
            currentWaveIndex++;
        }

        Debug.Log("All waves completed!");
    }


    private IEnumerator SpawnEnemiesInWave(EnemyWaveData waveData)
    {
         int totalEnemiesToSpawn = waveData.spawnAmount + (currentWaveIndex * waveData.enemiesPerWaveIncrease);

        for (int i = 0; i < totalEnemiesToSpawn; i++)
        {
           
            findSpawnPositions.SpawnObject = waveData.enemyPrefab;

            findSpawnPositions.StartSpawn(MRUK.Instance.GetCurrentRoom());

            yield return new WaitForSeconds(waveData.spawnDelay);
        }

        yield return new WaitForSeconds(waveData.BetweenWavesDelay);

         currentWaveIndex++;
    }

    



}
