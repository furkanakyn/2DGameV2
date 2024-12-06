using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public GameDirector gameDirector;
    public Player player;
    
    public Image healtFill;
    public Slider slider;
    
    private int _curHealth;
    private int _startHealth;



    public void SetMaxHealt(int healt)
    {
        healtFill.color = Color.white;
        slider.maxValue = healt;
        slider.value = healt;
        _curHealth = healt;
        _startHealth = healt;
    }
    public void TakeDamage(int damage)
    {
        _curHealth -= damage;
        slider.value = _curHealth;
        healtFill.color = Color.white;
        if (_curHealth < 60) 
        { 
            healtFill.color = new Color(1f, 0.5f, 0f);
        }
        if(_curHealth < 30)
        {
            healtFill.color = Color.red;
        }
        if (_curHealth <= 0)
        {
            player.gameObject.SetActive(false);
            gameDirector.LevelFailed();
        }
    }
    public void TakeHeal(int heal)
    {
        _curHealth += heal;
        if(_curHealth > _startHealth)
        {
            _curHealth = _startHealth;
        }
        slider.value = _curHealth;
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,-.7f,0);
    }
}
