using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Player player;
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
    }
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,-.65f,0);
    }
}
