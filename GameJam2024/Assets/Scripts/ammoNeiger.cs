using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoNeiger : MonoBehaviour
{
    private ammoSpawner ammoSpawner;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        ammoSpawner = GetComponent<ammoSpawner>();

        if (ammoSpawner == null) {
            ammoSpawner = FindAnyObjectByType<ammoSpawner>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) 
        {
            Destroy(this.gameObject, 0);
            ammoSpawner.AmmoCollected();
            player.ajouteMunition();
        }
    }
}
