using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKamikazi : MonoBehaviour {
    public Transform targetObj;
    public float speed;
    public float minDistance = 0f;
    public int degats = 10;

    public int vieEnemy = 5;

    private void Start() {
        targetObj = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        float distanceToPlayer = Vector3.Distance(transform.position, targetObj.position);

        if (distanceToPlayer > minDistance) {
            transform.position = Vector3.MoveTowards(current: this.transform.position, targetObj.position, maxDistanceDelta: speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //other.GetComponent<Joueur>().SubirDegats(degats);

            // Destroy after explosion
            Destroy(this.gameObject, 2f);

            if (other.CompareTag("Bullet")) {
                vieEnemy -= 2;
                if (vieEnemy <= 0) {
                    Destroy(this.gameObject, 2f);
                }
            }
        }
    }
}