using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed;

    public void StartBullet(float playerBulletSpeed)
    {
        bulletSpeed = playerBulletSpeed;
    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * bulletSpeed;
    }
}
