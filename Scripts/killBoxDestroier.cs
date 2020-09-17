using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBoxDestroier : MonoBehaviour {



    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {

            GameObject spike = GameObject.FindGameObjectWithTag("Spike");
            
            spike.gameObject.SetActive(false);



        }
    }
}
