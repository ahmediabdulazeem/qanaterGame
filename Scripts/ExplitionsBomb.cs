using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplitionsBomb : MonoBehaviour {


   // public float raduis = 5f;
   // public float force = 700f; 

    public GameObject ExplotionEffect;
    public bool hasExploded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


    public void Exploid() {


        Instantiate(ExplotionEffect,transform.position,transform.rotation);


        Destroy(gameObject,0.1f);

    }
}
