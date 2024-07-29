using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public int damage;
    public float maxSpeed;
    public float minSpeed;
    public GameObject explosionFX;

    private float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //play the explosion
            Vector3 pos = this.transform.position;
            Instantiate(explosionFX, pos, Quaternion.identity);
            
            //destroy the fireball
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Player p = other.gameObject.GetComponent<Player>();
            //damage the player
            p.damage(damage);
            //play the explosion
            Vector3 pos = this.transform.position;
            Instantiate(explosionFX, pos, Quaternion.identity);
            //destroy the fireball
            Destroy(gameObject);
        }
    }
}
