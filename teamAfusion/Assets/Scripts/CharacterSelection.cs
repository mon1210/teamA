using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection: MonoBehaviour
{ 
    public GameObject[] selectButton = new GameObject[6];
    public bool [] isSelect=new bool[6];
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
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
        Choice();
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
    public void OnButton4()
    {
        isSelect[3] = !isSelect[3];
        Debug.Log("押された");
    }
    public void OnButton5()
    {
        isSelect[4] = !isSelect[4];
        Debug.Log("押された");
    }
    public void OnButton6()
    {
        isSelect[5] = !isSelect[5];
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
        if (isSelect[3] == false)
        {
            selectButton[3].SetActive(false);
        }
        else
        {
            selectButton[3].SetActive(true);
        }
        if (isSelect[4] == false)
        {
            selectButton[4].SetActive(false);
        }
        else
        {
            selectButton[4].SetActive(true);
        }
        if (isSelect[5] == false)
        {
            selectButton[5].SetActive(false);
        }
        else
        {
            selectButton[5].SetActive(true);
        }
    }

    void Choice()
    {
        counter = 0;
        for(int i= 0;i<6;i++)
        {
            if (isSelect[i]==true)
            {
                counter++;
            }             
        }
        if(counter == 3)
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("反応");
        }
    }

}
