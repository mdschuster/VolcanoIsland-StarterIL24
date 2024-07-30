using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject thingToSpawn;
    public float timeBetweenSpawns; //in seconds

    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        time = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance().isPlayerAlive()==false) return;
            
        if (time <= 0)
        {
            //do the spawn
            float y = 7;
            float x = Random.Range(-8f, 8f);
            Vector3 pos = new Vector3(x, y, 0);
            Instantiate(thingToSpawn, pos, Quaternion.identity);

            time = timeBetweenSpawns;
        }
        else
        {
            //continue counting down
            time -= Time.deltaTime;
        }
    }
}
