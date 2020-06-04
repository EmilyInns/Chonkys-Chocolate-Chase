using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    Enemy parentEnemy;
    BoxCollider2D myFeetCollider;
    // Start is called before the first frame update
    void Start()
    {
        parentEnemy = GetComponentInParent<Enemy>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if(!(other.GetComponentInParent<Player>())){

            if(parentEnemy){ parentEnemy.TurnAround(); }

        }
        
    }

    public bool isTouchingGround(){
        return myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
