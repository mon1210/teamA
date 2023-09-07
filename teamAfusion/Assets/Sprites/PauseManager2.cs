using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager2 : MonoBehaviour
{
    //　アイテムメニューを開くボタン
    [SerializeField]
    private GameObject itemButton;
    //　ゲーム再開ボタン
    [SerializeField]
    private GameObject reStartButton;
    //　アイテムメニューパネル
    [SerializeField]
    private GameObject itemPanel;
    //タイトルに戻るボタン
   // [SerializeField]
   // private GameObject titleButton;

    public void StopGame()
    {
        Time.timeScale = 0f;
        itemButton.SetActive(false);
        reStartButton.SetActive(true);
        itemPanel.SetActive(true);
        
    }

    public void ReStartGame()
    {
        itemPanel.SetActive(false);
        reStartButton.SetActive(false);
        itemButton.SetActive(true);
      //  titleButton.SetActive(false);      
        Time.timeScale = 1f;
    }
    
}
