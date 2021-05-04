using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    public Rigidbody2D rg;
    public float velocity = 2;
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal")*velocity;

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw("Vertical")*velocity;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rg.velocity = movement ;

    }
 
}
