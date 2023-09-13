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

    [SerializeField] private string[] sceneName;

    [SerializeField] private Button[] startButton;

    [SerializeField] private Button[] Button;

    private EventTrigger[] trigger;

    // Start is called before the first frame update
    void Start()
    {
        eventTrigger();
        sceneName = new string[selectButton.Length];
        isSelect = new bool[selectButton.Length];
        

        for (int i = 0; i < selectButton.Length; i++)
        {
            //ボタンの選択を全て取り消す
            isSelect[i] = false;
        }
        buttonCilcEvet();
        
    }
    private void eventTrigger()
    {
        for (int i = 0; i < selectButton.Length; i++)
        {
            trigger[i] = selectButton[i].GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((enentDate) => { Debug.Log("押した"); });
            trigger[i].triggers.Add(entry);
        }
    }

    private void buttonCilcEvet()
    {
        for (int i = 0; i < Button.Length; i++)
            Button[i].onClick.AddListener(() => changSelectFlag(i));
        for (int i = 0; i < startButton.Length; i++)
            startButton[i].onClick.AddListener(() => clickButton());
    }


    private void changSelectFlag(int i)
    {
        //クリックされるたびにONとOFFを切り替える
        isSelect[i] = !isSelect[i];
        selectButton[i].SetActive(isSelect[i]);
        Debug.Log("押された");

    }

   
    
    //キャラクター選択結果にシーン移動する処理
     private void clickButton()
    {
        for(int i= 0;i<isSelect.Length;i++)
        {
            if (isSelect[i])
            {
                SceneManager.LoadScene(sceneName[i]);
            }
        }
    }

}
