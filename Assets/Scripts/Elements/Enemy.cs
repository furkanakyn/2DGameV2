using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
