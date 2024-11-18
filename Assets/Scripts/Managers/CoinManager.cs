using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int collectedCoinCount;

    public void IncreaseCointCount(int count)
    {
        collectedCoinCount += count;
    }
}
