using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public int startHealth;
    private int _currentHealth;
    public float speed;
    public TextMeshPro healthTMP;
    public SpriteRenderer spriteRenderer;
    private bool _didSpawnCoin;

    public Coin coinPrefab;
    public PowerUp powerUpPrefab;
    public bool isBoss;


    public void StartEnemy(Player player)
    {
        _player = player;
        startHealth += Random.Range(1, 10);
        startHealth += 10 * (player.shootDirections.Count - 1);
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
        spriteRenderer.DOKill();


        if (_currentHealth <= 0) 
        {
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
            
            spriteRenderer.DOKill();
            gameObject.transform.DOKill();
            Destroy(gameObject);
        }

    }
    

    
}
