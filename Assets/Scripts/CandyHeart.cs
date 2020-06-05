using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHeart : Candy
{
    

    protected override void PickupEffect()
    {
        gameSession.addScore(scoreValue);
        gameSession.AddLife();
        player.StarPower();
    }
}
