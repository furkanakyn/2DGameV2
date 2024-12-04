using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameDirector _gameDirector;
    private float _bulletSpeed;
    private Vector3 _dir;


    public void StartBullet(float playerBulletSpeed, Vector3 direction,GameDirector gameDirector)
    {
        _bulletSpeed = playerBulletSpeed;
        _dir = direction;
        _gameDirector = gameDirector;
    }
    void Update()
    {
        transform.position += _dir * Time.deltaTime * _bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {

            collision.GetComponent<Enemy>().GetHit(1);
            _gameDirector.FXManager.PlayBulletHitPS(transform.position);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Border"))
        {

            gameObject.transform.DOKill();
            Destroy(gameObject);
        }
    }
}
