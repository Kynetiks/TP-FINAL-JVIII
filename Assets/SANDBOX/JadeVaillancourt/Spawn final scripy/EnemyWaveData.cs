using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveData", menuName = "TowerDefense/EnemyWaveData")]
public class EnemyWaveData : ScriptableObject
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi à spawn
    public int initialEnemyCount = 10; // Nombre d'ennemis dans la première vague
    public float spawnInterval = 1.0f; // Temps entre chaque spawn d'ennemi
    public float timeBetweenWaves = 3.0f; // Temps entre les vagues d'ennemis
    public int enemiesPerWaveIncrease = 5; // Augmenter le nombre d'ennemis par vague
   
 
}
