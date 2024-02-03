using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionUI : MonoBehaviour
{
    //Gestion de la vie du joueur 
    public Text texteVie;

    public Player joueur;

  

    // Update is called once per frame
    void Update()
    {
        AfficherVie();
    }

    private void AfficherVie()
    {
        texteVie.text = "Vie: " + joueur.pointsVie.ToString();
    }
}
