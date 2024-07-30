using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int maxHealth;
    public float speed;

    private int health; //current health
    private Rigidbody2D rb;
    private Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");
        //animation stuff
        if (input > 0)
        {
            //tell the state machine that I am running
            anim.SetBool("isRunning",true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (input < 0)
        {
            //tell the state machine that I am running
            anim.SetBool("isRunning",true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            //tell the state machine that I am not running
            anim.SetBool("isRunning",false);
        }
        
        
        
        float x = speed*input;
        float y = 0;
        rb.velocity = new Vector2(x,y);
    }

    public void reset()
    {
        health = maxHealth;
        Vector3 pos = new Vector3(0f, -3.9f, 0f);
        transform.position = pos;
        gameObject.SetActive(true);
    }

    public void damage(int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            //destroy the player (set active to false)
            //tell the GM to show GameOver UI
            GameManager.instance().activateGameOver();
            //play a sound
            //play a particle system
            
            gameObject.SetActive(false);
        }
    }
}
