using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public GameObject enemies;
    public float spawntime = 3f;
    public Transform[] spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", spawntime, spawntime);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        

        if (player.currenthealth <= 0)
        {
            return;
        }
        int spawnindex = Random.Range(0, spawnpoints.Length);
        Instantiate(enemies, spawnpoints[spawnindex].position, spawnpoints[spawnindex].rotation);
        
    }
}
