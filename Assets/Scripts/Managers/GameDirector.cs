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

    public int levelNo;
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
        mainUI.SetLevelText(PlayerPrefs.GetInt("HighestLevelReached"));
        healtBar.healtFill.color = Color.white;
    }
    public void LevelFailed()
    {
        mainUI.LevelFailed();
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
    public void LevelCompleted()
    {
        PlayerPrefs.SetInt("HighestLevelReached", PlayerPrefs.GetInt("HighestLevelReached") + 1);
        mainUI.LevelCompleted();
    }
}
