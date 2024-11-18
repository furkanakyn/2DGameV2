using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed;
    private Vector3 _dir;


    public void StartBullet(float playerBulletSpeed, Vector3 direction)
    {
        _bulletSpeed = playerBulletSpeed;
        _dir = direction;
    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {

            collision.GetComponent<Enemy>().GetHit(1);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Border"))
        {

            gameObject.transform.DOKill();
            Destroy(gameObject);
        }
    }
}