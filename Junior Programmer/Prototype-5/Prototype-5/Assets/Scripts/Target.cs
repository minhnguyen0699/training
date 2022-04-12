using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;
    public ParticleSystem explosion;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position= RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generate random force 
    Vector3 RandomForce()
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        return Vector3.up * speed;
    }
    // Generate random torque
    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
    }
    // Generate random position
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    //click to destroy
    private void OnMouseDown()
    {
        if (gameManager.isGameActive) { 
        Destroy(gameObject);
        }
        Instantiate(explosion, transform.position, explosion.transform.rotation);

        gameManager.UpdateScore(pointValue);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

}
