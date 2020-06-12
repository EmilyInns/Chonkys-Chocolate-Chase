﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    float lastVelocity;


    [SerializeField] float starPowerTime = 8f;
    [SerializeField] float deathTime = 2f;
    [SerializeField] float soundVolume = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,10f);
    [SerializeField] GameObject StarVFX;
    [SerializeField] AudioClip JumpSound;

    [Header("States")]
    bool isAlive = true;
    bool starPowered = false;

[Header ("Cached Component References")]
    Rigidbody2D myRigidbody;
    Animator myAnimatior;
    CapsuleCollider2D myBodyCollider;
    Feet myFeet;
    SpriteRenderer mySprite;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimatior = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponentInChildren<Feet>();
        mySprite = GetComponentInChildren<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive){ return; }
        Run();
        Jump();
        flipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalspeed = Mathf.Abs(myRigidbody.velocity.x)> Mathf.Epsilon;
        if(playerHasHorizontalspeed){
        myAnimatior.SetBool("isRunning", true);
        lastVelocity = myRigidbody.velocity.x;
        
        }
        else{ myAnimatior.SetBool("isRunning", false); }
    }

    private void Jump(){
        bool feetOnGround = myFeet.isTouchingGround();
        if(!(feetOnGround)){ return; }

        else if(Input.GetButtonDown("Jump")){
            
                 Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
            AudioSource.PlayClipAtPoint(JumpSound, Camera.main.transform.position, soundVolume);
            }
           
        
    }

    private void flipSprite(){
        
        myAnimatior.SetBool("isFlipped", lastVelocity < 0); 

    }

    public void HitByEnemy()
    {
        if(isAlive){
            StartCoroutine(Die());
            
        }
    }

    private IEnumerator Die()
    {
        isAlive = false;
        deathKick.x = Mathf.Sign(myRigidbody.velocity.x)*deathKick.x * -1;
        myRigidbody.velocity = deathKick;
        myAnimatior.SetTrigger("Die");
        yield return new WaitForSeconds(deathTime);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    public bool GetIsAlive(){
        return isAlive;
    }

        public void StarPower()
    {
        Debug.Log("In starpower");
        if(!starPowered)
        {
            StartCoroutine(PoweredUp());
        }
        
    }

    private IEnumerator PoweredUp()
    {
        starPowered = true;
        Debug.Log("starpowered!");
        GetComponentInChildren<SpriteRenderer>().color = new Color(255,23,26,255);
        var starVFXRotation = new Vector3(-90,0,1);
        Quaternion myRotation = Quaternion.identity;
        myRotation.eulerAngles = starVFXRotation;
        GameObject StarVFXobject = Instantiate(StarVFX, transform.position, myRotation);
        StarVFXobject.transform.parent = gameObject.transform;
        
        yield return new WaitForSeconds(starPowerTime);
        starPowered = false;
        Debug.Log("star end");
        GetComponentInChildren<SpriteRenderer>().color = new Color(255,255,255,255);
    }

    public bool isStarPowered(){
        return starPowered;
    }
}
