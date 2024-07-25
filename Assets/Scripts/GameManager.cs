using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public static GameManager instance()
    {
        return _instance;
    }

    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        //reset the player
        player.reset();

    }

}
