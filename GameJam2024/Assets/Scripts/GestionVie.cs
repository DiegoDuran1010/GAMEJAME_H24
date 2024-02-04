using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionVie : MonoBehaviour
{
    public int pointsVie = 3, pointsMax = 3;
    public Image[] coeur;
    public Sprite hearts;
    public Sprite emptyHeart;


    void Update()
    {
        foreach (Image img in coeur)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < pointsVie; i++)
        {
            coeur[i].sprite = hearts;
        }
    }

    public void GagnerPointVie()
    {
        pointsVie += 1;
        print(pointsVie);
    }

    public void PerdreVie()
    {
        pointsVie -= 1;
    }
}