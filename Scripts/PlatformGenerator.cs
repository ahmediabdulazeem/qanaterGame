using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform PlatformgenerationPoint;
    public float distanceBetweem;

    private float platformWidth;
    

    public float distanceBetweenMin;
    public float distanceBetweenmax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;
    

    public ObjectBooler[] thePlatformsPools;
    

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreehold;

    public float randomSpikeThreehold;
    public ObjectBooler spikePool;

    public float randomSawThreehold;
    public ObjectBooler SawPool;

    public float powerupHeight;
    public ObjectBooler powerupPool;
    public float powerupThreehold;

    public ObjectBooler powerPool;
    public float powerThreehold;

    public ObjectBooler addsKidesclubBooler;
    public ObjectBooler castleBooler;
    public ObjectBooler buildingspooler;

    private ScoreManger thScoreManger;

  

	// Use this for initialization
	void Start () {

        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        
        

        platformWidths = new float[thePlatformsPools.Length];



        for (int i = 0; i < thePlatformsPools.Length; i++) {

            platformWidths[i] = thePlatformsPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
        thScoreManger = FindObjectOfType<ScoreManger>();

	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < PlatformgenerationPoint.position.x) {

            distanceBetweem = Random.Range(distanceBetweenMin, distanceBetweenmax);

            platformSelector = Random.Range(0, thePlatformsPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            platformSelector = Random.Range(0, thePlatformsPools.Length);

           /* if (heightChange > maxHeight) {

                heightChange = maxHeight;
            } else if (heightChange < minHeight) {

                heightChange = minHeight;
            }
           */
            if (Random.Range(0f,100f) < powerupThreehold) {


                GameObject newPowerup = powerupPool.GetPooledObject();

                newPowerup.transform.position = transform.position + new Vector3(distanceBetweem/2f,Random.Range(powerupHeight/2f,powerupHeight),0f);

                newPowerup.SetActive(true);

            }
            if (Random.Range(0f,100f) < powerThreehold) {

                GameObject newpower = powerPool.GetPooledObject();

                newpower.transform.position = transform.position + new Vector3(distanceBetweem / 2f, Random.Range(powerupHeight / 2f, powerupHeight), 0f);

                newpower.SetActive(true);


            }


           transform.position = new Vector3(transform.position.x  + distanceBetweem + (platformWidths[platformSelector] / 4f), transform.position.y , transform.position.z);
            

            // Instantiate(theObjectPools[platformSelector] , transform.position , transform.rotation);

            GameObject newPlatform = thePlatformsPools[platformSelector].GetPooledObject();

             newPlatform.transform.position = transform.position;
             newPlatform.transform.rotation = transform.rotation;
       
             newPlatform.SetActive(true);




            if (Random.Range(0f,100f)< randomCoinThreehold)
            {

                float CoinYpostion = Random.Range(transform.position.y+3.5f, transform.position.y + 6f);
                float CoinXpostion = Random.Range(transform.position.x - 4f, transform.position.x + 4f);

                theCoinGenerator.SpawnCoins(new Vector3(CoinXpostion, CoinYpostion, transform.position.z));

            }
            if (Random.Range(0f,100f)< randomSpikeThreehold)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector] /6f , platformWidths[platformSelector] / 6f );
                
                    Vector3 spikePosition = new Vector3(spikeXPosition, transform.position.y - 4f, 0f);

                    newSpike.transform.position = transform.position + spikePosition;
                    newSpike.transform.rotation = transform.rotation;
                    newSpike.SetActive(true);
                

            }

            if (Random.Range(0f, 100f) < randomSawThreehold)
            {
                GameObject newSaw = SawPool.GetPooledObject();

                float sawXPosition = Random.Range(-platformWidths[platformSelector] / 7f , platformWidths[platformSelector] / 7f);

                Vector3 SawPosition = new Vector3(sawXPosition, transform.position.y -4.5f , 0f);

                newSaw.transform.position = transform.position + SawPosition;
                newSaw.transform.rotation = transform.rotation;
                newSaw.SetActive(true);
                
            }

            
            

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 4f) + distanceBetweem, transform.position.y, transform.position.z);



        }



        if (Mathf.Round(Time.deltaTime) == 50f)
        {

            GameObject newaddskidsclub = addsKidesclubBooler.GetPooledObject();
            newaddskidsclub.transform.position = transform.position + new Vector3(distanceBetweem / Random.Range(5f, 12f), transform.position.y - 1.7f, 0f);

            newaddskidsclub.SetActive(true);
        }

        if (thScoreManger.scoreCount == 400f)
        {
            GameObject newcastle = castleBooler.GetPooledObject();
            newcastle.transform.position = transform.position + new Vector3(distanceBetweem / Random.Range(5f, 12f), transform.position.y + 2.5f, 0f);

            newcastle.SetActive(true);
        }

        if (thScoreManger.scoreCount == 700f || thScoreManger.scoreCount == 1700f)
        {
            GameObject newbuildings = buildingspooler.GetPooledObject();
            newbuildings.transform.position = transform.position + new Vector3(distanceBetweem / Random.Range(5f, 12f), transform.position.y + 0.7f, 0f);

            newbuildings.SetActive(true);
        }


    }
}
