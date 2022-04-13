using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody playerRb;
    public float speed;
    public Vector2 turn;
    public float sensitivity = .5f;
    public Transform orientation;
    Vector3 moveDirection;
    private Counter counter;

    // Start is called before the first frame update
    void Start()
    {
         playerRb = GetComponent<Rigidbody>();
        counter = GameObject.Find("Box").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        transform.localRotation = Quaternion.Euler(-turn.y,turn.x,0 );

        playerRb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        //playerRb.AddForce(Vector3.forward * speed * verticalInput);
        //playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("golfball"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            counter.updateScore(-1);
        }
    }
}
