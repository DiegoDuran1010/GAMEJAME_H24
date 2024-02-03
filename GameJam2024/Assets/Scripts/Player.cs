using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody rb_joueur;
    public float speed = 5f;
    public float smooth = 0.05f;
    private float _currentVelocity;
    public GameObject bullet;
    public float forceMagnitude = 10f;
    public float destructionTime = 5f;
    public int pointsVie = 5;
    public Animator monAnim;
    private bool bouge = false;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb_joueur = GetComponent<Rigidbody>();
        rb_joueur.freezeRotation = true;
        monAnim = GetComponent<Animator>();
        
    }


    void Update()
    {
       
        MouvementJoueur();
        if ((Input.GetMouseButtonDown(0)) )
        {
            monAnim.SetBool("isFire",true);
            Tirer();
        }
        else
        {
            monAnim.SetBool("isFire",false);
        }
        
    }


    


    public void SubirDegats(int degats)
    {
        pointsVie -= degats;

        if (pointsVie <= 0)
        {
            Mourir();
        }
    }

    private void Mourir()
    {
        gameObject.SetActive(false);
        //faut gerer le gameover ici
    }

    void Tirer()
    {
        GameObject sphere = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();

        if (rb != null)
        {
            
            //Ajoute une force dans la direction du joueur
            rb.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
        }
        else
        {
            
            Debug.LogError("Le bullet doit avoir un component Rigidbody");
        }

        Destroy(sphere, destructionTime);
    }

    void MouvementJoueur()
    {
        bouge = true;
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {

            direction += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {

            direction += Vector3.right;
        }

        direction = direction.normalized;

        if (direction.magnitude >= 0.1f)
        {
            monAnim.SetBool("isWalking", true);
            Quaternion nouvelleRotation = Quaternion.LookRotation(direction, Vector3.up);
            rb_joueur.MoveRotation(nouvelleRotation);
            rb_joueur.AddForce(direction * speed);
        }
        else
        {
            bouge = false;
            monAnim.SetBool("isWalking",false);
        }
    }
}