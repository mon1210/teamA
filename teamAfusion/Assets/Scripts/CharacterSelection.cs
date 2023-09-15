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
    [SerializeField] GameObject[] selectButton = new GameObject[6];
    //選択状態取得
    [SerializeField] bool[] isSelect;
    //テキスト取得
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < selectButton.Length; i++)
        {
            //ボタンの選択を全て取り消す
            isSelect[i] = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //枠の表示切り替え
        selectChecker();
    }
    //選択ボタンの処理
   public void OnSelectButton()
   {     
       //クリックされるたびにONとOFFを切り替える
        isSelect[0] = !isSelect[0];  
   }
   public void OnSelectButton2()
   {
        isSelect[1] = !isSelect[1];
   }
   public void OnSelectButton3()
   {
        isSelect[2] = !isSelect[2];
   }
   public void OnSelectButton4()
   {
        isSelect[3] = !isSelect[3];
   }
   public void OnSelectButton5()
   {
        isSelect[4] = !isSelect[4];
   }
   public void OnSelectButton6()
   {
        isSelect[5] = !isSelect[5];
   }
    //合成ボタンの処理
    public void OnStartButton()
    {
        clickButton();
    }
        //選択されているかどうかの処理
   private void selectChecker()
   {
      for (int i = 0; i < selectButton.Length; i++) 
      {
            //枠を非表示
          if (isSelect[i]== true)
          {
              selectButton[i].SetActive(true);
          }
          //枠を表示
          else
          {
              selectButton[i].SetActive(false);
          }
      }

   }
    //キャラクター選択結果にシーン移動する処理
    private void clickButton()
    {
            if (isSelect[0] == true )
            {
                SceneManager.LoadScene("FirstSynthesisScene");
            }
            else if (isSelect[1] == true )
            {
                SceneManager.LoadScene("FirstSynthesisScene");
            }
            else if (isSelect[2] == true)
            {
                SceneManager.LoadScene("ThirdSynthesisScene");
            }
            else if (isSelect[3] == true )
            {
                SceneManager.LoadScene("FirstSynthesisScene");
            }
            else if (isSelect[4] == true)
            {
                SceneManager.LoadScene("SecondSynthesisScene");
            }
            else if (isSelect[5] == true)
            {
                SceneManager.LoadScene("SecondSynthesisScene");
            }

    }

}