using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public TextMeshPro healthTMP;
    private Player _player;
    private GameDirector _gameDirector;
    public float speed;
    private int _health;

    private int _playerHealth;

    private void Start()
    {
        _health = Random.Range(1, 5);
        healthTMP.text = _health.ToString();
        
    }
    public void StartPowerUp()
    {
        transform.DOScale(1.2f, .2f).SetLoops(-1, LoopType.Yoyo);
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
    public void IncreaseHealth(int damage)
    {
        _health += damage;
        healthTMP.text = _health.ToString();
    }
    public int GetHealthAmount() 
    {
        return _health;
    }
    public void UpdateHealth(GameDirector gameDirector)
    {
        _gameDirector = gameDirector;
        gameDirector.healtBar.TakeHeal(_health);
    }
}
