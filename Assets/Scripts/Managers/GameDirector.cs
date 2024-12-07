using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public CoinManager coinManager;
    public FXManager FXManager;
    public AudioManager audioManager;
    public Player player;
    public HealtBar healtBar;
    public MainUI mainUI;
    public PowerUp powerUp;
    public Enemy enemy;

    public int levelNo;
    public int enemiesKilled = 0; 
    public int coinsCollected = 0;
    public int enemiesMissed = 0;

    void Start()
    {
        RestartLevel();
 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    public void RestartLevel()
    {
        levelNo = PlayerPrefs.GetInt("HighestLevelReached");
        player.RestartPlayer();
        enemyManager.RestartEnemyManager();
        mainUI.RestartMainUI();
        RestartScore();
        mainUI.SetLevelText(PlayerPrefs.GetInt("HighestLevelReached"));
        enemyManager.ClearSceneObjects();
    }
    public void LevelFailed()
    {
        mainUI.LevelFailed(enemiesKilled,enemiesMissed,coinsCollected);
        enemyManager.ClearSceneObjects();
        RestartScore();
        enemyManager.DeleteAndStopEnemy();
        audioManager.PlayFailAS();
    }
    public void SetInitalLevel()
    {
        var initalLevel = PlayerPrefs.GetInt("HighestLevelReached");
        if(initalLevel == 0)
        {
            initalLevel = 1;
        }
        PlayerPrefs.SetInt("HighestLevelReached",initalLevel);
    }
    public void SetInitalCoin()
    {
        var initalCoin = PlayerPrefs.GetInt("TotalCoin");
        PlayerPrefs.SetInt("TotalCoin", initalCoin + 1);
     
    }
    public void LevelCompleted()
    {
        PlayerPrefs.SetInt("HighestLevelReached", PlayerPrefs.GetInt("HighestLevelReached") + 1);
        mainUI.LevelCompleted(enemiesKilled, enemiesMissed, coinsCollected);
        audioManager.PlayVictoryAS();
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
    }

    public void CoinCollected()
    {
        coinsCollected++;
       
    }
    public void EnemyMissed()
    {
        enemiesMissed++;
    }
    void RestartScore()
    {
        enemiesKilled = 0;
        coinsCollected = 0;
        enemiesMissed = 0;
    }
   

}
