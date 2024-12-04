using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public GameDirector gameDirector;
    public Player player;
    public Image healtFill;
    private Slider slider;
    private int _curHealth;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
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
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,-.65f,0);
    }
}
