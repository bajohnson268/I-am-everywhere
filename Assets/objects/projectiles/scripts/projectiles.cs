using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class projectiles : MonoBehaviour
{

    //initialize variables
    public projectilesScript projectilesScript;
    public bool damageCharacter = true;
    public bool damageEnemy = true;

    public float angle;

    Coroutine damageCoroutine;

    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;
    Transform trans;

    void OnEnable() {

        //sets the rigidBody and sets a timer on the projectile to destroy itself 
        rb2D = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        angle += 90;
        trans.rotation = Quaternion.Euler(0, 0, angle+90);
        Object.Destroy(gameObject, projectilesScript.time);

        angle *= Mathf.Deg2Rad;

    }

    void FixedUpdate() {

        move();
    
    }

    public void move()
    {

        movement.y = Mathf.Sin(angle);
        movement.x = Mathf.Cos(angle);

        // keeps projectile moving at the same rate of speed, no matter which direction they are moving in
        movement.Normalize();

        // set velocity of RigidBody2D and move it
        rb2D.velocity = movement * projectilesScript.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.CompareTag("Player") && damageCharacter && collision.isTrigger)) {

            Object.Destroy(gameObject);
            collision.gameObject.GetComponent<character>().damageCoroutine = StartCoroutine(collision.gameObject.GetComponent<character>().DamageCharacter(projectilesScript.damage, 0));

        }

        //checks if the collision is with a trigger or not
        if (!collision.isTrigger)
        {

            //checks it the collision is with an enemy
            if ((collision.gameObject.CompareTag("enemy") && damageEnemy))
            {

                //destroys the projectile and deals damage
                Object.Destroy(gameObject);
                collision.gameObject.GetComponent<character>().damageCoroutine = StartCoroutine(collision.gameObject.GetComponent<character>().DamageCharacter(projectilesScript.damage, 0));

            }

            //checks if the collision is with a wall
            else if (collision.gameObject.CompareTag("wall"))
            {

                //destroys the projectile
                Object.Destroy(gameObject);

            }

        }
    }

    public static float setAngle(Vector3 start, Vector3 end)
    {

        float FinalAngle = Mathf.Rad2Deg * Mathf.Atan((end.y - start.y) / (end.x - start.x));

        if (start.x > end.x)
        {

            FinalAngle += 90;

        }

        else {

            FinalAngle -= 90;

        }

        return FinalAngle;

    }
}
