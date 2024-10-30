using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public void StartEnemyManager()
    {
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        var newEnemy = Instantiate(enemyPrefab);

    }
}
