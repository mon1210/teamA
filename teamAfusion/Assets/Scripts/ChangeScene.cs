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
            //�{�^���̑I����S�Ď�����
            isSelect[i] = false;
        }      
    }

    // Update is called once per frame
    void Update()
    {
        //�g�̕\���؂�ւ�
        ClickChecker();
    }
    public void OnButton()
    {
        //�N���b�N����邽�т�ON��OFF��؂�ւ���
        isSelect[0] = !isSelect[0];
        Debug.Log("�����ꂽ");      
    }
    public void OnButton2()
    {
        isSelect[1] = !isSelect[1];
        Debug.Log("�����ꂽ");
    }
    public void OnButton3()
    {
        isSelect[2] = !isSelect[2];
        Debug.Log("�����ꂽ");
    }

    void ClickChecker()
    {
        //�I������Ă��Ȃ���Θg���\������
        if (isSelect[0] == false)
        {
            selectButton[0].SetActive(false);
        }
        //�I������Ă�Θg��\������
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
