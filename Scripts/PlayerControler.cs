using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float moveSpeed;
    public float powerSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    private bool stopJumping;
    private bool CanDoubleJump;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask WhatIsGrounded; 
    public Transform groundCheck;
    public float groundCheckRadius;

    private Rigidbody2D myRigidbody2d;
    private Animator myAnimation;
    //private Collider2D myCollider; 

    public GameManger theGameManger;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource boomSound;
    public AudioSource waterSound;

    public GameObject expEffect;
    public GameObject bloodeffect;
    public GameObject runningSmoke;
    public GameObject blasmaEffect;
    

    public bool playerMod;
    public GameObject normaolBk;
    public GameObject heroBk;

    public float heroModCounter;

    // Use this for initialization
    void Start () {

        myRigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimation = GetComponent<Animator>();




        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedMilestoneCount;
        runningSmoke.SetActive(true);
        stopJumping = true;

        playerMod = true;
       

    }

   

    // Update is called once per frame
    void Update () {

       

        //grounded = Physics2D.IsTouchingLayers(myCollider,WhatIsGrounded);
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,WhatIsGrounded);

        if (!playerMod) {

            if (heroModCounter >= 0) {

                heroModCounter -= Mathf.RoundToInt(Time.deltaTime);
                Debug.Log(heroModCounter -= Time.deltaTime);
                
            }
            
        }
        


        if (transform.position.x > speedMilestoneCount) {

            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody2d.velocity = new Vector2(moveSpeed, myRigidbody2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ||Input.touchCount > 0) {

            if (grounded)
            {
                runningSmoke.SetActive(true);
                myRigidbody2d.velocity = new Vector2(myRigidbody2d.velocity.x, jumpForce);
                stopJumping = false;
                jumpSound.Play();

            }
            if (!grounded && CanDoubleJump) {

                myRigidbody2d.velocity = new Vector2(myRigidbody2d.velocity.x, jumpForce);

                runningSmoke.SetActive(false);
                jumpTimeCounter = jumpTime;
                runningSmoke.SetActive(false);
                stopJumping = false; 
                CanDoubleJump = false; 

            }


        }

        if (Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0) || Input.touchCount > 0 && !stopJumping) {

            if (jumpTimeCounter > 0 ) {

                runningSmoke.SetActive(false);
                myRigidbody2d.velocity = new Vector2( myRigidbody2d.velocity.x , jumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }

        }

        if (Input.GetKeyUp(KeyCode.Space)|| Input.GetMouseButtonUp(0) || Input.touchCount > 0) {

            runningSmoke.SetActive(false);
            jumpTimeCounter = 0;
            stopJumping = true;

        }
        
        if (grounded) {

            runningSmoke.SetActive(true);
            jumpTimeCounter = jumpTime;
            CanDoubleJump = true;

        }

        myAnimation.SetFloat("Speed", myRigidbody2d.velocity.x);
        myAnimation.SetBool("Grounded", grounded);
       
        
        
	}

     void OnCollisionEnter2D(Collision2D other)
    {
      

        if (other.gameObject.tag == "KillBox")
        {

            theGameManger.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            waterSound.Play();

            deathSound.Play();

        }
        if (other.gameObject.tag == "saw" && !playerMod )
        {
            GameObject saw = GameObject.FindGameObjectWithTag("saw");

            
            saw.SetActive(false);


        }
        if (other.gameObject.tag == "Spike" && !playerMod)
        {
            GameObject spike = GameObject.FindGameObjectWithTag("Spike");
            boomSound.Play();

            Instantiate(expEffect, transform.position, transform.rotation);
            spike.gameObject.SetActive(false);
        }



        if ( playerMod || heroModCounter <= 0)
        {
           
            runningSmoke.SetActive(true);
            blasmaEffect.SetActive(false);
            normaolBk.SetActive(true);
            heroBk.SetActive(false);
            
            if (other.gameObject.tag == "Spike")
            {
                GameObject spike = GameObject.FindGameObjectWithTag("Spike");
                boomSound.Play();

                Instantiate(expEffect, transform.position, transform.rotation);
                
                spike.gameObject.SetActive(false);



                theGameManger.RestartGame();
                moveSpeed = moveSpeedStore;
                speedMilestoneCount = speedMilestoneCountStore;
                speedIncreaseMilestone = speedIncreaseMilestoneStore;

                deathSound.Play();

            }
            if (other.gameObject.tag == "saw")
            {
                GameObject saw = GameObject.FindGameObjectWithTag("saw");

                Instantiate(bloodeffect, transform.position, transform.rotation);


                theGameManger.RestartGame();
                moveSpeed = moveSpeedStore;
                speedMilestoneCount = speedMilestoneCountStore;
                speedIncreaseMilestone = speedIncreaseMilestoneStore;

                deathSound.Play();

            }

        }



         if (other.gameObject.tag == "Power" )
        {
            playerMod = false;
           

          

            runningSmoke.SetActive(false);
            blasmaEffect.SetActive(true);
            normaolBk.SetActive(false);
            heroBk.SetActive(true);

            

            GameObject power = GameObject.FindGameObjectWithTag("Power");
            power.gameObject.SetActive(false);

            moveSpeed = moveSpeed * powerSpeed;

            



        }
       

    }


}
 