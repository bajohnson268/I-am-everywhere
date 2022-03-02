using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enable))]

public class pedestalScript : MonoBehaviour
{
    //variables
    public bool isFilled;
    Inventory inventory;
    public Item display;

    //a cooldown to prevent it from taking more than one item
    float pickupRate = .05f;
    float pickupCooldown;

    private void OnTriggerEnter2D(Collider2D collision) {

        //if the collison is with a player, it's not already filled, and the cooldown is not active
        if (collision.gameObject.CompareTag("Player") && !isFilled && Time.time > pickupCooldown) {

            //gets the inventory of the player
            inventory = collision.gameObject.GetComponent<player>().inventory;

            //if the player has the desired item, it takes it from the inventory
            if (inventory.RemoveItem(display)) {

                //sets isFilled and shows the object
                isFilled = true;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = display.sprite;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

                gameObject.GetComponent<enable>().isOn = true;


            }

        }

        //updates the cooldown
        pickupCooldown = Time.time + pickupRate;

    }

}
