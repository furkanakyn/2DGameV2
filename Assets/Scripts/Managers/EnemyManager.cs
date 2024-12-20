using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Player player;
    public Enemy enemyPrefab;
    public Enemy bossEnemyPrefab;

    public Transform coinsParent;
    public Transform powersParent;

    public float enemyYSpacing;
    private int _spawnedEnemyCount;

    private Coroutine _enemyGenerationCoroutine;
    public Transform coinsContainer;
    public Transform powerUpsContainer;

    public List<Enemy> _enemies = new List<Enemy>();
    public void RestartEnemyManager()
    {
        DeleteEnemies();
        if (_enemyGenerationCoroutine != null)
        {
            StopCoroutine(_enemyGenerationCoroutine);
        }
        _enemyGenerationCoroutine = StartCoroutine(EnemyGenerationCoroutine());
        _spawnedEnemyCount = 0;
    }

    private void DeleteEnemies()
    {
        _enemies.RemoveAll(e => e == null);
        foreach (Enemy e in _enemies)
        {
            Destroy(e.gameObject);
        }
        _enemies.Clear();
    }
    public void DeleteAndStopEnemy()
    {
        DeleteEnemies();
        StopCoroutine(_enemyGenerationCoroutine);
    }
    IEnumerator EnemyGenerationCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f + Random.Range(0,2f));
            var enemeyCountBonus = (gameDirector.levelNo - 1) * 5;
            enemeyCountBonus = Mathf.Min(enemeyCountBonus, 95);
            if (_spawnedEnemyCount < 5 + enemeyCountBonus)
            {
                if (Random.value < .75f)
                {
                    SpawnEnemy();
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

    void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab);
        var enemyXPos = Random.Range(-2.2f, 2.2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnedEnemyCount++;
        _enemies.Add(newEnemy);
        newEnemy.StartEnemy(player , gameDirector, coinsParent,powersParent);
    }

    void SpawnTwoEnemies()
    {
        var newEnemy = Instantiate(enemyPrefab);
        var enemyXPos = Random.Range(1f, 2.2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnedEnemyCount++;
        _enemies.Add(newEnemy);
        newEnemy.StartEnemy(player, gameDirector, coinsParent, powersParent);

        var newEnemy2 = Instantiate(enemyPrefab);
        var enemyXPos2 = Random.Range(-1f, -2.2f);
        var enemyYPos2 = 5 * enemyYSpacing;
        newEnemy2.transform.position = new Vector3(enemyXPos2, enemyYPos2, 0);
        _spawnedEnemyCount++;
        _enemies.Add(newEnemy2);
        newEnemy2.StartEnemy(player, gameDirector, coinsParent, powersParent);
    }

    void SpawnBoss()
    {
        var newEnemy = Instantiate(bossEnemyPrefab);
        var enemyXPos = Random.Range(-2f, 2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnedEnemyCount++;
        _enemies.Add(newEnemy);
        newEnemy.StartEnemy(player, gameDirector, coinsParent, powersParent);
    }
    public void ClearSceneObjects()
    {
        foreach (Transform child in coinsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in powerUpsContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
