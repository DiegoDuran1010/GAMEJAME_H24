using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuivisCamera : MonoBehaviour
{
    public Transform joueur;


    // Update is called once per frame
    void Update()
    {
        if (joueur != null)
        {
            Vector3 newPosition = new Vector3(joueur.position.x, transform.position.y, joueur.position.z);
            transform.position = newPosition;
        }
    }
}
