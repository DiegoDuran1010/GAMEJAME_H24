using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Transform targetObj;
    public float speed;
    public float minDistance = 0f;
    public int degats = 10;

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
            print("DAMAGE");

            //other.GetComponent<Joueur>().SubirDegats(degats);

        }
    }

}
