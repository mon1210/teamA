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
   

    public void stopGame()
    {
        //時間停止
        Time.timeScale = 0f;
        //itemButton非表示
        itemButton.SetActive(false);
        //reStartButton表示
        reStartButton.SetActive(true);
        //itemPanel表示
        itemPanel.SetActive(true);
        
    }

    public void reStartGame()
    {
        //itemPanel非表示
        itemPanel.SetActive(false);
        //reStartButton非表示
        reStartButton.SetActive(false);
        //itemButton表示
        itemButton.SetActive(true);
        //時は動き出す
        Time.timeScale = 1f;
    }
    
}
