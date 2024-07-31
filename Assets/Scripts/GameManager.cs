using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Canvas gameOverCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        //reset the player
        reset();

    }

    public bool isPlayerAlive()
    {
        return player.gameObject.activeSelf;
    }

    public void activateGameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
    
    
    public void reset() 
    {
        player.reset();
        gameOverCanvas.gameObject.SetActive(false);
        //if needed, reset other things too.
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

}
