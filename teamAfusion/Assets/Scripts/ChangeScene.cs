using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene: MonoBehaviour
{
    public GameObject[] selectButton = new GameObject[3];
    public bool [] isSelect=new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            //ボタンの選択を全て取り消す
            isSelect[i] = false;
        }      
    }

    // Update is called once per frame
    void Update()
    {
        //枠の表示切り替え
        ClickChecker();
    }
    public void OnButton()
    {
        //クリックされるたびにONとOFFを切り替える
        isSelect[0] = !isSelect[0];
        Debug.Log("押された");      
    }
    public void OnButton2()
    {
        isSelect[1] = !isSelect[1];
        Debug.Log("押された");
    }
    public void OnButton3()
    {
        isSelect[2] = !isSelect[2];
        Debug.Log("押された");
    }

    void ClickChecker()
    {
        //選択されていなければ枠を非表示する
        if (isSelect[0] == false)
        {
            selectButton[0].SetActive(false);
        }
        //選択されてれば枠を表示する
        else 
        {
            selectButton[0].SetActive(true);
        }

        if (isSelect[1] == false)
        {
            selectButton[1].SetActive(false);
        }
        else
        {
            selectButton[1].SetActive(true);
        }

        if (isSelect[2] == false)
        {
            selectButton[2].SetActive(false);
        }
        else
        {
            selectButton[2].SetActive(true);
        }
    }

}
