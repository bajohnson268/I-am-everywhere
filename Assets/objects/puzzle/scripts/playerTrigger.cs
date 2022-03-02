using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(enable))]
[RequireComponent(typeof(toIsActive))]

public class playerTrigger : MonoBehaviour
{

    //variables
    [HideInInspector]
    public bool isActive;
    public bool isToggle;
    public bool isConstant;
    SpriteRenderer sprite;

    int numIn = 0;

    public void OnEnable()
    {

        //sets the spriteRenderer
        sprite = gameObject.GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //checks if the collision is with a player
        if (collision.gameObject.CompareTag("Player"))
        {

            numIn++;

            //if its not already active
            if (!isActive )
            {

                //sets isActive to true and changes the sprite
                isActive = true;
                sprite.color = Color.gray;
                

                gameObject.GetComponent<enable>().toggle();
                gameObject.GetComponent<toIsActive>().toggle();

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //checks if the collision is with a player and that its a toggle
        if (collision.gameObject.CompareTag("Player") && (isToggle || isConstant))
        {

            numIn--;

            //if it is active
            if (isActive && numIn == 0)
            {

                //sets isActive to false and changes the sprite
                isActive = false;
                sprite.color = Color.white;

                if (!isToggle) {

                    gameObject.GetComponent<enable>().toggle();
                    gameObject.GetComponent<toIsActive>().toggle();

                }
            }

        }

    }

}
