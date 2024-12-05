using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public Player player;
    public Bullet bulletPrefab;
    public Transform bulletsParent;

   
    public float playerMoveSpeed;
    public float playerBulletSpeed;
    public float playerXBorders;
    public float playerYBorders;
    public float attackRate;
    
    
    public int enemyDamage;
    public int startHealth;
    private int _curHealth;

    public List<Vector3> shootDirections;


    private Vector3 _mousePivotPos;
    private Coroutine _shootCoroutine;


    public void RestartPlayer()
    {
        gameObject.SetActive(true);
        _curHealth = startHealth;
        gameDirector.healtBar.SetMaxHealt(startHealth);
        transform.position = new Vector3(0, -2.8f, 0);
        StopShooting();
        shootDirections.Clear();
        shootDirections.Add(Vector3.up);
    }

    private void StartShooting()
    {
        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShooting()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
        }
    }

    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            _curHealth -= enemyDamage;
            UpdateHealthBar(enemyDamage);
            gameDirector.FXManager.PlayPlayerHitFX(transform.position);

        }
        if (collision.CompareTag("Coin"))
        {
            gameDirector.coinManager.IncreaseCointCount(1);
            gameDirector.FXManager.PlayCoinCollectedFX(collision.transform.position);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("PowerUp"))
        {
            shootDirections.Add(new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized);
            collision.gameObject.SetActive(false);

            var powerUp = collision.GetComponent<PowerUp>();
            if (powerUp != null)
            {
                int healthAmount = powerUp.GetHealthAmount();
                IncreaseHealth(healthAmount);
            }
        }
    }
    public void IncreaseHealth(int healAmount)
    {
        _curHealth += healAmount;
        if (_curHealth > startHealth) 
            _curHealth = startHealth;

        
        gameDirector.healtBar.TakeHeal(healAmount);
    }
    void UpdateHealthBar(int damage)
    {
        gameDirector.healtBar.TakeDamage(damage);
    }
    void MovePlayer()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            _mousePivotPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            direction = Input.mousePosition - _mousePivotPos;
        }
        transform.position += direction * playerMoveSpeed * Time.deltaTime;
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

            for (int i = 0; i < shootDirections.Count; i++)
            {
                    Shoot(shootDirections[i]);
                    
            }
        }
    }
    void Shoot(Vector3 dir)
    {
        var newBullet = Instantiate(bulletPrefab, bulletsParent);
        newBullet.transform.position = transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        newBullet.StartBullet(playerBulletSpeed, dir, gameDirector);
        gameDirector.audioManager.PlayBulletAS();
    }

}
