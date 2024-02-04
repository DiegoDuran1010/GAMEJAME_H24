using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoSpawner : MonoBehaviour {
    public GameObject ammoPrefab;
    public int maxAmmoCount = 2;
    //public int numberOfAmmo = 5;
    public float spawnRadius = 10f;
    public float spawnDelay = 1f; // Adjust the delay between each enemy spawn
    public LayerMask obstacleLayer; // Layer for obstacles
    public Transform playerTransform;

    private int currentAmmoCount = 0;

    private void Start() {
        if (playerTransform == null) {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        InvokeRepeating("SpawnAmmo", 0.5f, spawnDelay);
    }

    private void SpawnAmmo() {
        if (currentAmmoCount < maxAmmoCount) {
            Vector3 randomPosition = GetRandomPosition();

            // If not on an obstacle and if is far enough away from player, spawn
            if (!IsObstructed(randomPosition) && Vector3.Distance(randomPosition, playerTransform.position) >= 10f) {
                Instantiate(ammoPrefab, randomPosition, Quaternion.identity);
                currentAmmoCount++;
            }

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

    public void AmmoCollected() {
        currentAmmoCount = Mathf.Max(currentAmmoCount - 1);
    }
}
