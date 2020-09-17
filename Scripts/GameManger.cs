using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Transform bkgenerator;
    private Vector3 bkstartpoint;

    public PlayerControler thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManger theScoreManger;

    public DeathMenu theDeathMenu;
    public bool powerupRest;

    private float startheroCounter;

    

	// Use this for initialization
	void Start () {

        platformStartPoint = platformGenerator.position;
        bkstartpoint = bkgenerator.position;
        playerStartPoint = thePlayer.transform.position;
        startheroCounter = thePlayer.heroModCounter;

        
        
        theScoreManger = FindObjectOfType<ScoreManger>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void RestartGame() {

        //StartCoroutine("RestartGameCo");
        theDeathMenu.gameObject.SetActive(true);
        
        theScoreManger.scoreIncreasing = false;

        thePlayer.gameObject.SetActive(false);
        

        
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        bkgenerator.position = bkstartpoint;
        thePlayer.heroModCounter = startheroCounter;
        thePlayer.gameObject.SetActive(true);

        theScoreManger.scoreCount = 0;
        theScoreManger.scoreIncreasing = true;

        thePlayer.playerMod = true;


        powerupRest = true;

    }

        

   /* public IEnumerator RestartGameCo() {

        theScoreManger.scoreIncreasing = false;

        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++) {

            platformList[i].gameObject.SetActive(false);

        }


        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManger.scoreCount = 0;
        theScoreManger.scoreIncreasing = true;
        

    }*/


}
