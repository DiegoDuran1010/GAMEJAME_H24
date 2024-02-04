using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flocon : MonoBehaviour
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
