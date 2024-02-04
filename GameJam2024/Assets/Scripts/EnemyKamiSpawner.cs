using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamiSpawner : MonoBehaviour {
    public GameObject enemyKamikaziPrefab;
    public int numberOfEnemies = 5;
    public float spawnRadius = 10f;
    public float spawnDelay = 1f; // Adjust the delay between each enemy spawn
    public LayerMask obstacleLayer; // Layer for obstacles
    public Transform playerTransform;

    private void Start() {
        if (playerTransform == null) {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    private void SpawnEnemy() {
        if (numberOfEnemies > 0) {
            Vector3 randomPosition = GetRandomPosition();

            // If not on an obstacle and if is far enough away from player, spawn
            if (!IsObstructed(randomPosition) && Vector3.Distance(randomPosition, playerTransform.position) >= 10f) {
                Instantiate(enemyKamikaziPrefab, randomPosition, Quaternion.identity);
                numberOfEnemies--;
            }
        } else {
            // Stop invoking if all enemies are spawned
            CancelInvoke("SpawnEnemy");
        }
    }

    private Vector3 GetRandomPosition() {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPosition = new Vector3(randomCircle.x, 2f, randomCircle.y) + transform.position;
        return randomPosition;
    }

    private bool IsObstructed(Vector3 position) {
        // Checks for obstacles
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * 2f, Vector3.down, out hit, 5f, obstacleLayer)) {
            // The distance of the check is 5 (cannot spawn within 5 of obstacles)
            return true;
        }
        return false;
    }
}
