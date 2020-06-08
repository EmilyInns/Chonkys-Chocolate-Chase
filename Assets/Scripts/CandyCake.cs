using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCake : Candy
{
    

    protected override void PickupEffect()
    {
        gameSession.addScore(scoreValue);
        player.StarPower();
    }
}
