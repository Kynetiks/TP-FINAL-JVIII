using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveData", menuName = "TowerDefense/EnemyWaveData")]
public class EnemyWaveData : ScriptableObject
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi à spawn
    public int spawnAmount = 10; // Nombre d'ennemis par vague
    public float spawnDelay = 0.5f; // Temps entre chaque spawn d'ennemi
    public float BetweenWavesDelay = 3.0f; // Temps entre les vagues d'ennemis
    public int enemiesPerWaveIncrease = 10; // Augmenter le nombre d'ennemis par vague
   
 
}
