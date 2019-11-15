using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Rigidbody2D rigbod;
    float baseSpeed = 5.0f;
    float horizontalInput = 0.0f;
    float verticalInput = 0.0f;
    int health = 100;
    CircleCollider2D collide;
    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
        collide = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetMovementInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));//temporary to test moving around the unit
        rigbod.velocity = new Vector2(baseSpeed * horizontalInput, baseSpeed * verticalInput);
    }

    //To be used by the player object
    public void SetMovementInput(float horizontal, float vertical)
    {
        horizontalInput = horizontal;
        verticalInput = vertical;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            print("Ded");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.name);
    }
}
