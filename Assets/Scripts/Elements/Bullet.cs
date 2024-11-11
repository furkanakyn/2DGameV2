using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed;


    public void StartBullet(float playerBulletSpeed)
    {
        _bulletSpeed = playerBulletSpeed;
        
    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.GetComponent<Enemy>().GetHit(1);
        }
        if (collision.CompareTag("Border"))
        {
            gameObject.SetActive(false);
        }
    }
}
