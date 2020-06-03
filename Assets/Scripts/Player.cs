using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    [Header("States")]
    bool isAlive = true;

[Header ("Cached Component References")]
    Rigidbody2D myRigidbody;
    Animator myAnimatior;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimatior = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
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
        }
        else{ myAnimatior.SetBool("isRunning", false); }
    }

    private void Jump(){
        if(!(myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))){ return; }

        if(Input.GetButtonDown("Jump")){
            
                 Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
            }
           
        
    }

    private void flipSprite(){
        bool playerHasHorizontalspeed = Mathf.Abs(myRigidbody.velocity.x)> Mathf.Epsilon;
        gameObject.transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
    }
}
