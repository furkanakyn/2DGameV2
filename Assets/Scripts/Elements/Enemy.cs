using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _startHealth;
    private int _currentHealth;
    public float speed;
    public TextMeshPro healthTMP;
    public SpriteRenderer spriteRenderer;
    private bool _didSpawnCoin;

    public Coin coinPrefab;
    public PowerUp powerUpPrefab;

    private void Start()
    {
        _startHealth += Random.Range(1, 20);
        _currentHealth = _startHealth;
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
                _didSpawnCoin = true;
            }
            spriteRenderer.DOKill();
            gameObject.transform.DOKill();
            Destroy(gameObject);
        }

    }
    

    
}
