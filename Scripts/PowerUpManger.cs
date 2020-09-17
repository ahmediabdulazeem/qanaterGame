using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManger : MonoBehaviour {

    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLenghtCounter;

    private ScoreManger theScoreManager;
    private PlatformGenerator thePlateformGenerator;

    private GameManger theGameManager;

    private float normalPointPerSceond;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;


    // Use this for initialization
    void Start () {

        theScoreManager = FindObjectOfType<ScoreManger>();
        thePlateformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManger>();

		
	}
	
	// Update is called once per frame
	void Update () {

        if (powerupActive) {

            powerupLenghtCounter -= Time.deltaTime;

            if (theGameManager.powerupRest)
            {
                powerupLenghtCounter = 0;
                theGameManager.powerupRest = false;

            }

            if (doublePoints)
            {

                theScoreManager.pointsPerSecond = normalPointPerSceond * 2.75f;
                theScoreManager.shouldDouble = true;

                
            }
            if (safeMode)
            {

                thePlateformGenerator.randomSpikeThreehold = 0f;

            }
            if (powerupLenghtCounter <= 0)
            {

                theScoreManager.pointsPerSecond = normalPointPerSceond;
                theScoreManager.shouldDouble = false; 

                thePlateformGenerator.randomSpikeThreehold = spikeRate;


                powerupActive = false;
            }
            



        }


		
	}


    public void ActivatePowerup(bool points , bool safe , float time) {

        doublePoints = points;
        safeMode = safe;
        powerupLenghtCounter = time;

        normalPointPerSceond = theScoreManager.pointsPerSecond;
        spikeRate = thePlateformGenerator.randomSpikeThreehold;

         

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();

            for (int i = 0; i > spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("spikes") ) {
                    spikeList[i].gameObject.SetActive(false);
                }
            }

        }

        powerupActive = true;

    }


}
