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
    public AudioSource bgAS;

   
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
        bgAS.Stop();
    }
    public void PlayVictoryAS()
    {
        victoryAS.Play();
        bgAS.Stop();
    }
    public void PlayCoinCollectedAS()
    {
        coinAS.Play();
    }
    public void PlayBGAS()
    {
        bgAS.Play();
        failAS.Stop();
        victoryAS.Stop();
    }
    
}
