using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationEnemy : MonoBehaviour
{
    public GameObject myObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.myObj.activeSelf == true)
        {
            Animator.enabled = true;
        }

    }
}
