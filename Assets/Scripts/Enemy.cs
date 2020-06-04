using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D myRigidBody;
    SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
       // myRigidBody.velocity = new Vector2(enemySpeed, 0f);
       mySprite = GetComponentInChildren<SpriteRenderer>();
    }

    internal void TurnAround()
    {
        moveSpeed = -moveSpeed;
        mySprite.flipX ^= true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

        private void Move()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }
 

    private void OnTriggerEnter2D(Collider2D other)
    {
     Player player = other.gameObject.GetComponent<Player>();
     if (player){
         player.HitByEnemy();
     }
        
}
}

