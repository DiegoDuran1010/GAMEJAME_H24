using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarreGlace : MonoBehaviour
{
    public float glace = 50f;
    public float maxGlace = 50f;

    public Image barreGlaceImage;

    // Update is called once per frame
    void Update()
    {
        barreGlaceImage.fillAmount = glace / maxGlace;  

        if(glace > maxGlace)
        {
            glace = maxGlace;
        }
        if(glace < 0) 
        { 
            glace = 0f;
        }
    }
}
