using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionVie : MonoBehaviour
{
    public int pointsVie = 3;

    private int pointsVieActuelle;

    // Start is called before the first frame update
    void Start()
    {
        pointsVieActuelle = pointsVie;
    }

    public void GagnerPointVie()
    {
        pointsVieActuelle += 1;
        print(pointsVieActuelle);
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
}