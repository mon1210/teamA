using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection: MonoBehaviour
{ 

    public GameObject[] selectButton = new GameObject[7];
    public bool [] isSelect = new bool[7];
    [SerializeField] Text text;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
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
        ClickButton();


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
    public void OnButton4()
    {
        isSelect[3] = !isSelect[3];
        Debug.Log("�����ꂽ");
    }
    public void OnButton5()
    {
        isSelect[4] = !isSelect[4];
        Debug.Log("�����ꂽ");
    }
    public void OnButton6()
    {
        isSelect[5] = !isSelect[5];
        Debug.Log("�����ꂽ");
    }
    public void OnButton7()
    {
        isSelect[6] = !isSelect[6];
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
        if (isSelect[6] == false)
        {
            selectButton[6].SetActive(false);
        }
        else
        {
            selectButton[6].SetActive(true);
        }
    }
    //�L�����N�^�[�I�����ʂɃV�[���ړ����鏈��
    void ClickButton()
    {
        if (isSelect[0] == true && isSelect[6]==true)
        {
            SceneManager.LoadScene("ResultScene");
        }
        else if (isSelect[1] == true && isSelect[6] == true)
        {
            SceneManager.LoadScene("ResultScene2");
        }
        else if (isSelect[2] == true && isSelect[6] == true)
        {
            SceneManager.LoadScene("ResultScene3");
        }
        else if(isSelect[3] == true &&  isSelect[6] == true)
        {
            SceneManager.LoadScene("ResultScene4");
        }
        else if (isSelect[4] == true && isSelect[6] == true)
        {
            SceneManager.LoadScene("ResultScene");
        }
        else if(isSelect[5] == true &&  isSelect[6] == true)
        {
            SceneManager.LoadScene("ResultScene2");
        }      
    }

}
