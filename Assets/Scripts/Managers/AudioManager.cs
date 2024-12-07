using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bulletAS;
    public AudioSource enemyDestroyedAS;
    public AudioSource failAS;
    public AudioSource victoryAS;
    public AudioSource coinAS;


    public void PlayBulletAS()
    {
        bulletAS.Play();
    }
    public void PlayEnemyDestroyedAS()
    {
        enemyDestroyedAS.Play();
    }
    public void PlayFailAS()
    {
        failAS.Play();
    }
    public void PlayVictoryAS()
    {
        victoryAS.Play();
    }
    public void PlayCoinCollectedAS()
    {
        coinAS.Play();
    }
}
