using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public Bullet bulletPrefab;
   
    public float playerSpeed;
    public float playerBulletSpeed;
    public int bulletDamage;
    public float playerXBorders;
    public float playerYBorders;
    public float attackRate;
    public int extraShootCount;


    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Coin"))
        {
            gameDirector.coinManager.IncreaseCointCount(1);
            collision.gameObject.SetActive(false);
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
        else if (transform.position.x > playerXBorders)
        {
            pos.x = playerXBorders;

        }
        if (transform.position.y < -playerYBorders)
        {
            pos.y = -playerYBorders;

        }
        else if (transform.position.y > playerYBorders)
        {
            pos.y = playerYBorders;

        }
        transform.position = pos;
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);

            for (int i = 0; i < extraShootCount + 1; i++)
            {
                if (i == 0)
                {
                    Shoot(Vector3.up);
                }
                else if (i == 1)
                {
                    Shoot(new Vector3(-.25f, 1, 0));
                }
                else if (i == 2)
                {
                    Shoot(new Vector3(.25f, 1, 0));
                }
            }
        }
    }
    void Shoot(Vector3 dir)
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(playerBulletSpeed, dir);
    }

}
