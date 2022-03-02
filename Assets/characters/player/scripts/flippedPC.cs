using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flippedPC: MonoBehaviour
{
    // public variables appear as properties in Unity's inspector window
    public float movementSpeed;

    // holds 2D points; used to represent a character's location in 2D space, or where it's moving to
    Vector2 movement = new Vector2();

    Animator character;

    // reference to the character's Rigidbody2D component, location, and gameObject
    Rigidbody2D rb2D;

    // use this for initialization
    private void Start()
    {
        // get references to game object component so it doesn't have to be grabbed each time needed
        character = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // called once per frame
    private void Update()
    {

        UpdateState();

    }

    // called at fixed intervals by the Unity engine
    // update may be called less frequently on slower hardware when frame rate slows down
    void FixedUpdate()
    {

        MoveCharacter();

    }

    private void MoveCharacter()
    {
        // get user input
        // GetAxisRaw parameter allows us to specify which axis we're interested in
        // Returns 1 = right key or "d" (up key or "w")
        //        -1 = left key or "a"  (down key or "s")
        //         0 = no key pressed
        movement.x = -Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // keeps player moving at the same rate of speed, no matter which direction they are moving in
        movement.Normalize();

        // set velocity of RigidBody2D and move it
        rb2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        //sets the animation for walking right
        if (movement.x != 0 || movement.y != 0)
        {

            character.SetBool("isWalking", true);

        }

        else
        {

            character.SetBool("isWalking", false);

        }

        if (movement.x < 0)
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        else
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }

}