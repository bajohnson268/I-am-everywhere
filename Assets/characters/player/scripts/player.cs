using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : character
{
    // Used to get a reference to the prefab
    public HealthBar healthBarObject;
    public manaBar manaBar;
    public Inventory inventoryPrefab;
    public playerText text;

    [HideInInspector]
    public Inventory inventory;

    // A copy of the health bar prefab
    HealthBar healthBar;
    manaBar manaBarObject;
    playerText playertextObj;

    //coroutine for mana regen
    Coroutine manaRegen;

    float pickupRate = .05f;
    float pickupCooldown;

    float damageRate = .05f;
    float damageCooldown;

    [HideInInspector]
    public string textChar;

    // Start is called before the first frame update
    private void OnEnable()
    {
        ResetCharacter();
    }

    public override void KillCharacter()
    {

        SceneManager.LoadScene("dieScene", LoadSceneMode.Single);

        // Destroy the current game object and remove it from the scene
        Destroy(gameObject);

    }

    private void FixedUpdate() {



    }


    // Called when player's collider touches an "Is Trigger" collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Retrieve the game object that the player collided with, and check the tag, and check the cooldown to prevent double pickup
        if (collision.gameObject.CompareTag("canBePickedUp") && Time.time > pickupCooldown)
        {
            // Grab a reference to the Item (scriptable object) inside the Consumable class and assign it to hitObject
            // Note: at this point it is a coin, but later may be other types of CanBePickedUp objects
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            // Check for null to make sure it was successfully retrieved, and avoid potential errors
            if (hitObject != null)
            {

                // indicates if the collision object should disappear
                bool shouldDisappear = false;

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        // coins should disappear by default and should be added to inventory
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;

                    case Item.ItemType.HEALTH:
                        // hearts should disappear if they adjust the player's hit points
                        // when health meter is full, hearts aren't picked up and remain in the scene
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;

                    case Item.ItemType.ORB:
                        // orbs should disappear by default and should be added to inventory
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;

                    default:
                        break;
                }

                //set the cooldown
                pickupCooldown = Time.time + pickupRate;

                // Hide the game object in the scene to give the illusion of picking up
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }

        //checks if collision with enemy and that the collision isn't a trigger(enemy sight) and that damage is not on cooldown
        else if (collision.gameObject.CompareTag("enemy") && !collision.isTrigger && Time.time > damageCooldown)
        {

            float damage = collision.gameObject.GetComponent<Enemy>().damageStrength;

            if (damageCoroutine == null)
            {
                // Start the coroutine to inflict damage to the player every 1 second
                damageCoroutine = StartCoroutine(DamageCharacter((int)damage, 1.0f));

            }

            //sets cooldown
            damageCooldown = Time.time + damageRate;

        }

        //checks if the collision is with a projectile and the damage cooldown is not active
        else if (collision.gameObject.CompareTag("projectile") && Time.time > damageCooldown)
        {

            damageCooldown = Time.time + damageRate;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // See if the enemy has just stopped colliding with the player
        if (collision.gameObject.CompareTag("enemy") && !collision.isTrigger)
        {

            // If coroutine is currently executing
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }

        }

    }

    public bool AdjustHitPoints(int amount)
    {
        // Don't increase above the max amount
        if (hitPoints < maxHitPoints)
        {
            hitPoints = hitPoints + amount;
            //print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints);
            return true;
        }

        // Return false if hit points is at max and can't be adjusted
        return false;
    }

    public override void ResetCharacter()
    {

        // Start the player off with the starting hit point value
        hitPoints = startingHitPoints;

    }

}
