using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GestionFlocon : MonoBehaviour
{
    //son
    public AudioSource gainNeige;
    public AudioClip sfx;
    //gain neige
    private int gainDeNeige;

   void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if(other.CompareTag("Player"))
        {
            //sound effect
            gainNeige.clip = sfx;
            gainNeige.Play();
            if (player != null)
            {
                Destroy(gameObject);
            }
        }


    }

}
