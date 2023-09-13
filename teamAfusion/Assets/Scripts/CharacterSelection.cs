using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterSelection: MonoBehaviour
{
    //選択ボタンの取得
    [SerializeField] GameObject[] selectButton = new GameObject[7];
    //選択状態取得
    [SerializeField] bool[] isSelect;
    //テキスト取得
    [SerializeField] Text text;

    [SerializeField] private string[] sceneName;

    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = new string[selectButton.Length];
        isSelect = new bool[selectButton.Length];
        for (int i = 0; i < selectButton.Length - 1; i++)
        {
            //ボタンの選択を全て取り消す
            isSelect[i] = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //枠の表示切り替え
        clickChecker();
        clickButton();
    }
   public void OnButton()
   {
        for (int i = 0; i < selectButton.Length - 1; i++)
        {
            //クリックされるたびにONとOFFを切り替える
            isSelect[i] = !isSelect[i];
            Debug.Log("押された");
        }
   }
    private void clickChecker()
    {
        for (int i = 0; i < selectButton.Length - 1; i++) 
        {
            if (isSelect[i]== true)
            {
                selectButton[i].SetActive(true);
            }
            else
            {
                selectButton[i].SetActive(false);
            }
        }

    }
    //キャラクター選択結果にシーン移動する処理
    private void clickButton()
    {
        if (!isSelect[6]) return;
        {
            for (int i = 0; i < isSelect.Length - 1; i++)
            {
                if (isSelect[i])
                {
                    SceneManager.LoadScene(sceneName[i]);
                    break;
                }
            }
        }
    }

}