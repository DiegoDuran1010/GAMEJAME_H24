using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCoeur : MonoBehaviour
{
    public int gainDeVie = 1;
    public AudioSource src;
    public AudioClip sfx;

    void OnTriggerEnter(Collider other)
    {
        GestionVie vie = other.GetComponent<GestionVie>();

        if (other.CompareTag("Player"))
        {
            //sound effect
            src.clip = sfx;
            src.Play();

            if (vie != null)
            {
                vie.GagnerPointVie();
                if (vie.pointsVie < vie.pointsMax)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}