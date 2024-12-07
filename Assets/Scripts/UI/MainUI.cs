using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [Header("FAIL")]
    public CanvasGroup failCanvasGroup;
    public TextMeshProUGUI failKilledEnemyTMP;
    public TextMeshProUGUI failMissedEnemyTMP;
    public TextMeshProUGUI failCollectedCoinTMP;
    public TextMeshProUGUI failTotalCoin;
    public Button resButton;
    [Header("PROGRESS")]
    public GameObject progressParent;
    public TextMeshProUGUI levelTMP;
    public TextMeshProUGUI coinCountTMP;
    public Image levelIm;
    [Header("VICTORY")]
    public GameObject victoryParent;
    public CanvasGroup victoryCanvasGroup;
    public Button nextLevelButton;
    public TextMeshProUGUI victoryKilledEnemyTMP;
    public TextMeshProUGUI victoryMissedEnemyTMP;
    public TextMeshProUGUI victoryCollectedCoinTMP;
    public TextMeshProUGUI victoryTotalCoin;


    private void Update()
    {
        TextCoinCount();
    }
    public void RestartMainUI()
    {
        failCanvasGroup.gameObject.SetActive(false);
        victoryCanvasGroup.gameObject.SetActive(false);
        progressParent.gameObject.SetActive(true);
        victoryCanvasGroup.alpha = 0;
        failCanvasGroup.alpha = 0;

    }
    
    public void LevelFailed(int ke , int me , int cc)
    {
        failCanvasGroup.gameObject.SetActive(true);
        progressParent.gameObject.SetActive(false);
        failCanvasGroup.DOFade(1, 1);
        resButton.transform.DOScale(1.1f, 1f).SetLoops(-1, LoopType.Yoyo);
        failTotalCoin.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        failKilledEnemyTMP.text = "Killed enemy: " + ke;
        failMissedEnemyTMP.text = "Missed enemy: " + me;
        failCollectedCoinTMP.text = "Collected Coin: " + cc;
    }
    public void SetLevelText(int l)
    {
        levelTMP.text = "LEVEL " + l;
        levelTMP.DOKill();
        levelIm.DOKill();
        levelTMP.DOFade(1, 1f).SetLoops(2, LoopType.Yoyo);
        levelIm.DOFade(.7f, 1f).SetLoops(2, LoopType.Yoyo);
    }
    public void LevelCompleted(int ke, int me, int cc)
    {
        victoryCanvasGroup.gameObject.SetActive(true);
        victoryCanvasGroup.DOFade(1, .5f);
        nextLevelButton.transform.DOScale(1.1f, 1f).SetLoops(-1, LoopType.Yoyo);
        victoryTotalCoin.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        victoryKilledEnemyTMP.text = "Killed enemy: " + ke;
        victoryMissedEnemyTMP.text = "Missed enemy: " + me;
        victoryCollectedCoinTMP.text = "Collected Coin: " + cc;
    }

    public void TextCoinCount()
    {
        var getCoin = PlayerPrefs.GetInt("TotalCoin");
        coinCountTMP.text = "Coin: " + getCoin;
    }
}
