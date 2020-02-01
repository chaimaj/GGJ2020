using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float smoothrate;

    Transform player;
    Vector3 velocity;
    Vector3 newPos;

    void Start()
    {
        velocity = new Vector3(0.5f, 0.5f, 0);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        newPos = Vector3.zero;
    }

    void FixedUpdate()
    {
        newPos.x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity.x, smoothrate);
        newPos.y = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smoothrate);

        
        Vector3 newPosition = new Vector3(newPos.x, newPos.y, -10);
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.time);

    }

}
