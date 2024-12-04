using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public ParticleSystem coinCollectedPS;
    public ParticleSystem bulletHitPS;
    public ParticleSystem playerHitPS;
    public void PlayCoinCollectedFX(Vector3 pos)
    {
        var newPS = Instantiate(coinCollectedPS);
        newPS.transform.position = pos;
        newPS.Play();
        Destroy(newPS.gameObject, newPS.main.duration + newPS.main.startLifetime.constantMax);
    }
    public void PlayBulletHitPS(Vector3 pos)
    {
        var newPS = Instantiate(bulletHitPS);
        newPS.transform.position = pos;
        newPS.Play();
        Destroy(newPS.gameObject, newPS.main.duration + newPS.main.startLifetime.constantMax);
    }
    public void PlayPlayerHitFX(Vector3 pos)
    {
        var newPS = Instantiate(playerHitPS);
        newPS.transform.position = pos;
        newPS.Play();
        Destroy(newPS.gameObject, newPS.main.duration + newPS.main.startLifetime.constantMax);
    }
}
