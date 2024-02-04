using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoNeiger : MonoBehaviour
{
    public float pointsAmmo = 100f;

    public float ammoActuelle;

    // Start is called before the first frame update
    void Start()
    {
        ammoActuelle = pointsAmmo;
    }

    public void GagnerNeige()
    {
        ammoActuelle += 0.5f;
        print(ammoActuelle);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) 
        {
            Destroy(this.gameObject, 0);
        }
    }
}
