using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private GameDirector _gameDirector;
    public Coin coinPrefab;
    public PowerUp powerUpPrefab;

    public EnemyType enemyType;

    public int startHealth;
    private int _currentHealth;
    
    public float speed;
   
    public TextMeshPro healthTMP;
    public SpriteRenderer spriteRenderer;
    
    public bool isBoss;
    private bool _isEnemyDestroyed;

    public void StartEnemy(Player player, GameDirector gameDirector)
    {
        _player = player;
        _gameDirector = gameDirector;
        startHealth += Random.Range(1, 10);
        startHealth += 5 * (player.shootDirections.Count - 1);
        _currentHealth = startHealth;
        healthTMP.text = _currentHealth.ToString();
    }

    private void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
    
    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        healthTMP.text = _currentHealth.ToString();
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOScale(1.2f, .1f).SetLoops(2, LoopType.Yoyo);


        spriteRenderer.DOKill();
        spriteRenderer.color = Color.white;
        spriteRenderer.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);
        


        if (_currentHealth <= 0)
        {
            KillEnemy();
            Destroy(gameObject);
            spriteRenderer.DOKill();
            gameObject.transform.DOKill();
        }

    }

    private void KillEnemy()
    {
        _gameDirector.audioManager.PlayEnemyDestroyedAS();
        _gameDirector.EnemyKilled();
        if (!_isEnemyDestroyed)
        {   
            if(enemyType != EnemyType.Boss)
            {
                if (Random.value < .5f)
                {
                    var newCoin = Instantiate(coinPrefab);
                    newCoin.transform.position = transform.position + Vector3.forward;
                    newCoin.StartCoin();
                }
                else
                {
                    var newPowerUp = Instantiate(powerUpPrefab);
                    newPowerUp.transform.position = transform.position + Vector3.forward;
                    newPowerUp.StartPowerUp();
                }
            }
            else 
            {
                _player.gameDirector.LevelCompleted();
                _player.gameObject.SetActive(false);
            }
            _isEnemyDestroyed = true;
        }
    }

    public enum EnemyType
    {
        Basic,
        Fast,
        Shooting,
        Boss,
    }
}
