using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : character
{
    // Amount of damage the enemy will inflict when it runs into the player
    public int damageStrength;

    private void OnEnable()
    {

        ResetCharacter();
    }

    public void Update()
    {

        //if (hitPoints <= 0)
        //{

        //    gameObject.GetComponent<enable>().isOn = true;

        //}

    }

    //resets character
    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
    }

    //kills charcter
    public override void KillCharacter() {


        Destroy(gameObject);

    }

}
