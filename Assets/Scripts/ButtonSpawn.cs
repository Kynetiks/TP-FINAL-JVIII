using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    [SerializeField] private SpawnTower spawnTower; 



    public void ChangeTower(GameObject tower)
    {
        spawnTower.towerPrefab = tower;
    }
}
