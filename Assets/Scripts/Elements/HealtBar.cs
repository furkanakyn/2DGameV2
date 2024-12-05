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

    
    public void SetMaxHealt(int healt)
    {
       slider.maxValue = healt;
       slider.value = healt;
        _curHealth = healt;
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
        slider.value = _curHealth;
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,-.7f,0);
    }
}
