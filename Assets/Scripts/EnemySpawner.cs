using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab spawn
    public Transform spawnPoint; // Where enemies spawn
    public float spawnDelay = 2f; // Delay between spawns
    public int maxEnemies = 3; // Maximum number of enemies allowed to spawn
    
    public int currentEnemyCount = 0;

    void Start()
    {
        // Spawning loop
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        // Only will spawn if it is below the max number of enemies
        if (currentEnemyCount < maxEnemies)
        {
            currentEnemyCount++; // Increment enemy count

            // Spawn the enemy
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--; // Decrement enemy count 
    }
}
