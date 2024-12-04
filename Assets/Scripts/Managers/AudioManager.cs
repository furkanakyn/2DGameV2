using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bulletAS;
    public AudioSource enemyDestroyedAS;


    public void PlayBulletAS()
    {
        bulletAS.Play();
    }
    public void PlayEnemyDestroyedAS()
    {
        enemyDestroyedAS.Play();
    }
}
