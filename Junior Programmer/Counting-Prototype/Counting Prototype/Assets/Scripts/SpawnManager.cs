using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject golfPrefab;
    private float spawnRange = 3;
    public int golfCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("golfball").Length);
        if (GameObject.FindGameObjectsWithTag("golfball").Length == 0)
        {
            SpawnEnemyWave();
        }
    }

    private Vector3 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave()
    {
        
            Instantiate(golfPrefab, GenerateRandomPos(), golfPrefab.transform.rotation);
       
    }
}
