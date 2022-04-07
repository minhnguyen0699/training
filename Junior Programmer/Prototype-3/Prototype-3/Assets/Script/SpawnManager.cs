using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPost = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 1.5f;
    private PlayerController playerControllerScript;
   
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPost, obstaclePrefab.transform.rotation);
        }
       
    }
}
