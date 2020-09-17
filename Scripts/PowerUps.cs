﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public bool doublePoints;
    public bool safeMode;

    public float powerupLength;

    private PowerUpManger thePowerupManager;

    public Sprite[] powerupSprites;

	// Use this for initialization
	void Start () {

        thePowerupManager = FindObjectOfType<PowerUpManger>();

	}

     void Awake()
    {
        int powerupSelector = Random.Range(0,1);

        switch (powerupSelector)
        {   
            case 0:doublePoints = true;
                break;
            case 1:safeMode = true;
                break;

        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];
        
        
    }


   

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {

            

            thePowerupManager.ActivatePowerup(doublePoints , safeMode , powerupLength);

        }
        gameObject.SetActive(false);

    }

}