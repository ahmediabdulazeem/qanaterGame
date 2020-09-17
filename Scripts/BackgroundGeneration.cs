using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour {

    public GameObject theBackground;
    public Transform backgroundGenerationPoint;
    private float backgroundWidth;
    private float[] backgroundWidths;
    public ObjectBooler[] theBackgroundPools;
    private int backgroundSelector;



    // Use this for initialization
    void Start () {

        backgroundWidth = theBackground.GetComponent<BoxCollider2D>().size.x;

        backgroundWidths = new float[theBackgroundPools.Length];

        for (int i = 0; i < theBackgroundPools.Length; i++)
        {

            backgroundWidths[i] = theBackgroundPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

        }



    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < backgroundGenerationPoint.position.x)
        {

            backgroundSelector = Random.Range(0, theBackgroundPools.Length);

            transform.position = new Vector3(transform.position.x + backgroundWidths[backgroundSelector] , 1.49f, transform.position.z);

            GameObject newbackground = theBackgroundPools[backgroundSelector].GetPooledObject();


            newbackground.transform.position = transform.position;
            newbackground.transform.rotation = transform.rotation;
            newbackground.SetActive(true);

            transform.position = new Vector3(transform.position.x + backgroundWidths[backgroundSelector]-25f, 1.49f, transform.position.z);
            transform.position = new Vector3(transform.position.x + backgroundWidths[backgroundSelector]-25f, 1.49f, transform.position.z);



        }




    }
}
