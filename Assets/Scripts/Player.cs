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
    [SerializeField] float deathTime = 2f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,10f);

    [Header("States")]
    bool isAlive = true;

[Header ("Cached Component References")]
    Rigidbody2D myRigidbody;
    Animator myAnimatior;
    CapsuleCollider2D myBodyCollider;
    Feet myFeet;
    SpriteRenderer mySprite;

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
        }
        else{ myAnimatior.SetBool("isRunning", false); }
    }

    private void Jump(){
        bool feetOnGround = myFeet.isTouchingGround();
        if(!(feetOnGround)){ return; }

        else if(Input.GetButtonDown("Jump")){
            
                 Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
            }
           
        
    }

    private void flipSprite(){
        bool playerHasHorizontalspeed = Mathf.Abs(myRigidbody.velocity.x)> Mathf.Epsilon;
        gameObject.transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
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
        Debug.Log("Dead!");
        deathKick.x = Mathf.Sign(myRigidbody.velocity.x)*deathKick.x * -1;
        myRigidbody.velocity = deathKick;
        myAnimatior.SetTrigger("Die");
        yield return new WaitForSeconds(deathTime);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
}
