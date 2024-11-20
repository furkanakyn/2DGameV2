using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.transform.DOKill();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.transform.DOKill();
            Destroy(collision.gameObject);
        }
    }
}
