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
    public TextMeshProUGUI killedEnemyTMP;
    public TextMeshProUGUI missedEnemyTMP;
    public TextMeshProUGUI collectedCoinTMP;
    public TextMeshProUGUI totalCoin;
    public Button resButton;
    [Header("PROGRESS")]
    public GameObject progressParent;
    public TextMeshProUGUI levelTMP;
    public TextMeshProUGUI coinCountTMP;
    public Image levelIm;
    [Header("VICTORY")]
    public GameObject victoryParent;
    public CanvasGroup victoryCanvasGroup;


    private void Update()
    {
        TextCoinCount();
    }
    public void RestartMainUI()
    {
        failCanvasGroup.gameObject.SetActive(false);
        victoryCanvasGroup.gameObject.SetActive(false);
        levelTMP.gameObject.SetActive(true);
        levelIm.gameObject.SetActive(true);
        victoryCanvasGroup.alpha = 0;
        failCanvasGroup.alpha = 0;

    }
    
    public void LevelFailed(int ke , int me , int cc)
    {
        failCanvasGroup.gameObject.SetActive(true);
        progressParent.gameObject.SetActive(false);
        failCanvasGroup.DOFade(1, 1);
        resButton.transform.DOScale(1.1f, 1f).SetLoops(-1, LoopType.Yoyo);

        totalCoin.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        killedEnemyTMP.text = "Killed enemy: "+ ke;
        missedEnemyTMP.text = "Missed enemy: " + me;
        collectedCoinTMP.text = "Collected Coin: " + cc;
    }
    public void SetLevelText(int l)
    {
        levelTMP.text = "LEVEL " + l;
        levelTMP.DOKill();
        levelIm.DOKill();
        levelTMP.DOFade(1, 1f).SetLoops(2, LoopType.Yoyo);
        levelIm.DOFade(.7f, 1f).SetLoops(2, LoopType.Yoyo);
    }
    public void LevelCompleted()
    {
        victoryCanvasGroup.gameObject.SetActive(true);
        victoryCanvasGroup.DOFade(1, .5f);


    }
   public void TextCoinCount()
    {
        var getCoin = PlayerPrefs.GetInt("TotalCoin");
        coinCountTMP.text = "Coin: " + getCoin;
    }
}
