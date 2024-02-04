using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarreGlace : MonoBehaviour
{
    public float glace = 50f;
    public float maxGlace = 50f;
    public float valeurInitiale;
    public Image barreGlaceImage;

    private void Start()
    {
        valeurInitiale = barreGlaceImage.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
     

        if (Input.GetMouseButton(0))
        {
            
        }
        



    }
}
