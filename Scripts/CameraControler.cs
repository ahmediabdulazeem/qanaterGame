using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public PlayerControler thPlayer;

    private Vector3 LastPlayerPostion;
    private float distanceToMove;

	// Use this for initialization
	void Start () {

        thPlayer = FindObjectOfType<PlayerControler>();
        LastPlayerPostion = thPlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        distanceToMove = thPlayer.transform.position.x - LastPlayerPostion.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        LastPlayerPostion = thPlayer.transform.position; 


	}
}
