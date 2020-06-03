using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
       // myRigidBody.velocity = new Vector2(enemySpeed, 0f);
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
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}

