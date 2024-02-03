using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCoeur : MonoBehaviour
{
    public int gainDeVie = 1;

    void OnTriggerEnter(Collider other)
    {
        GestionVie vie = other.GetComponent<GestionVie>();

        if (other.CompareTag("Player"))
        {
            if (vie != null)
            {
                vie.GagnerPointVie();
                Destroy(gameObject);
            }
        }
    }
}