using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Enemy bossEnemyPrefab;
    public float enemyYSpacing;
    private int _spawnEnemyCount;
    public void StartEnemyManager()
    {
        _spawnEnemyCount = 0;
        StartCoroutine(EnemyGenerationCoroutine());
    }
    IEnumerator EnemyGenerationCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f + Random.Range(0,2f));
            if(_spawnEnemyCount < 20)
            {
                if (Random.value < .75f)
                {
                    SpawnNewEnemy();
                }
                else
                {
                    SpawnTwoEnemies();
                }
            }
            
            else
            {
                yield return new WaitForSeconds(1);
                SpawnBoss();
                break;
            }
        }
    }

    void SpawnNewEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab);
        var enemyXPos = Random.Range(-2.2f, 2.2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnEnemyCount++;
    }
    void SpawnTwoEnemies()
    {
        var newEnemy = Instantiate(enemyPrefab);
        var enemyXPos = Random.Range(1f, 2.2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        

        var newEnemy2 = Instantiate(enemyPrefab);
        var enemyXPos2 = Random.Range(-1f, -2.2f);
        var enemyYPos2 = 5 * enemyYSpacing;
        newEnemy2.transform.position = new Vector3(enemyXPos2, enemyYPos2, 0);
        _spawnEnemyCount += 2;
    }
    private void SpawnBoss()
    {
        var newEnemy2 = Instantiate(enemyPrefab);
        var enemyXPos2 = Random.Range(-2f, -2f);
        var enemyYPos2 = 5 * enemyYSpacing;
        newEnemy2.transform.position = new Vector3(enemyXPos2, enemyYPos2, 0);
        _spawnEnemyCount++;
    }
}
