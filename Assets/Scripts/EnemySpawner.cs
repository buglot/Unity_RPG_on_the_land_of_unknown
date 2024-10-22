using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;    // Enemy prefab to spawn
    public Transform player;          // Reference to the player
    public float minSpawnTime = 1f;   // Minimum time between spawns
    public float maxSpawnTime = 5f;   // Maximum time between spawns
    public float spawnRangeX = 30f;   // X-axis spawn range (±)
    public float spawnRangeY = 30f;   // Y-axis spawn range (±)
    public float safeZoneRadius = 5f; // Minimum distance from player to spawn enemy

    void Start()
    {
        Player player1 = GameObject.FindAnyObjectByType<Player>();
        player = player1.transform;
        StartCoroutine(SpawnEnemyAtRandomTime());
    }

    IEnumerator SpawnEnemyAtRandomTime()
    {
        while (true)
        {
            // Generate a random time between min and max spawn time
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            // Wait for the random time before spawning
            yield return new WaitForSeconds(randomTime);
            // Get a random spawn position outside the safe zone but within the range
            Vector3 spawnPosition = GetRandomPositionOutsideSafeZone();
            int random = Random.Range(0, enemyPrefab.Length);
            // Spawn the enemy at the calculated position
            Instantiate(enemyPrefab[random], spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionOutsideSafeZone()
    {
        Vector3 spawnPosition;

        do
        {
            // Generate random X and Y offsets around the player
            float randomOffsetX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomOffsetY = Random.Range(-spawnRangeY, spawnRangeY);

            // Calculate the new spawn position based on the player's position
            spawnPosition = new Vector3(player.position.x + randomOffsetX, player.position.y + randomOffsetY, 0);

            // Check the distance between the spawn position and the player
        } while (Vector3.Distance(spawnPosition, player.position) < safeZoneRadius);

        return spawnPosition;
    }
}

