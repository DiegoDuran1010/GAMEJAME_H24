using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

public class NewBehaviourScript : MonoBehaviour {
    public Transform targetObj;
    public Animator anim;
    public float speed;
    public float minDistance = 0f;
    public int degats = 10;

    public int vieEnemy = 10;

    private void Start() {
        anim = GetComponent<Animator>();
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
            other.GetComponent<GestionVie>().PerdreVie();

            //print("ATTACK");
            anim.SetBool("isShooting", true);
        }
        if (other.CompareTag("Bullet")) {
            vieEnemy -= 2;
            if (vieEnemy <= 0) {
                Destroy(this.gameObject, 0.5f);
            }
        }
    }

}
