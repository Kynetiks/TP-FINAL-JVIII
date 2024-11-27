using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private FindSpawnPositions findSpawnPositions;
    [SerializeField] private List<EnemyWaveData>enemyWaveDate = new List<EnemyWaveData>();
   
     [SerializeField] private float delayBeforeSpawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        findSpawnPositions.SpawnAmount = enemyWaveDate[0].initialEnemyCount;
        findSpawnPositions.StartSpawn(MRUK.Instance.GetCurrentRoom());

        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
