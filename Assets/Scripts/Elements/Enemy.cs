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
    public int startHealth;
    private int _currentHealth;
    public float speed;
    public TextMeshPro healthTMP;
    public SpriteRenderer spriteRenderer;
    private bool _didSpawnCoin;
    
    public Coin coinPrefab;
    public PowerUp powerUpPrefab;
    public bool isBoss;


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
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.2f;
        transform.DOScale(targetScale, .1f).SetLoops(2, LoopType.Yoyo);
        transform.DOKill();



        spriteRenderer.DOKill();
        spriteRenderer.color = Color.white;
        spriteRenderer.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);
        spriteRenderer.DOKill();


        if (_currentHealth <= 0) 
        {
            _gameDirector.audioManager.PlayEnemyDestroyedAS();
            if (!_didSpawnCoin)
            {
                if(Random.value < .5f)
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
                if (isBoss)
                {
                    _player.gameDirector.LevelCompleted();
                }
                _didSpawnCoin = true;
            }
   
            Destroy(gameObject);
            spriteRenderer.DOKill();
            gameObject.transform.DOKill();
        }

    }
    

    
}
