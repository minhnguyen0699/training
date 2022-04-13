using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector2 turn;
    public float sensitivity = 12.5f;

    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraControl();
    }

    void CameraControl()
    {
        transform.position = player.transform.position + offset;
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y +=Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation =Quaternion.Euler(-turn.y, turn.x, 0);
    }
}

