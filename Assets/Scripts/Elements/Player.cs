using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float playerXBorders;
    public float playerYBorders;
    void Start()
    {
        
    }

   
    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }
    void MovePlayer()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        transform.position += direction.normalized * playerSpeed * Time.deltaTime;
    }
    void ClampPlayerPosition()
    {
        var pos = transform.position;
        if (transform.position.x < -playerXBorders)
        {
            pos.x = -playerXBorders;

        }
        if (transform.position.x > playerXBorders)
        {
            pos.x = playerXBorders;

        }
        if (transform.position.y < -playerYBorders)
        {
            pos.y = -playerYBorders;

        }
        if (transform.position.y > playerYBorders)
        {
            pos.y = playerYBorders;

        }
        transform.position = pos;
    }
    void Shoot()
    {

    }
}
