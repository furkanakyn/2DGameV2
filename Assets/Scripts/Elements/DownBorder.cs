using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBorder : MonoBehaviour
{
    public GameDirector gameDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.transform.DOKill();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            DOTween.Kill(collision.gameObject);
            collision.gameObject.transform.DOKill();
            Destroy(collision.gameObject);
            gameDirector.EnemyMissed();
        }
        if (collision.CompareTag("PowerUp"))
        {
            collision.gameObject.transform.DOKill();
            Destroy(collision.gameObject);
        }
    }
}
