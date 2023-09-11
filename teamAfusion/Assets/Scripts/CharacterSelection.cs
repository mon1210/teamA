using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection: MonoBehaviour
{
    //�I���{�^���̎擾
    [SerializeField] GameObject[] selectButton = new GameObject[7];
    //�I����Ԏ擾
    [SerializeField] bool [] isSelect = new bool[7];
    //�e�L�X�g�擾
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
        clickChecker();
        clickButton();


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


    private void clickChecker()
    {
        //�I������Ă��Ȃ���Θg���\������
        if (isSelect[0])
        {
            selectButton[0].SetActive(false);
        }
        //�I������Ă�Θg��\������
        else 
        {
            selectButton[0].SetActive(true);
        }

        if (isSelect[1])
        {
            selectButton[1].SetActive(false);
        }
        else
        {
            selectButton[1].SetActive(true);
        }

        if (isSelect[2])
        {
            selectButton[2].SetActive(false);
        }
        else
        {
            selectButton[2].SetActive(true);
        }

        if (isSelect[3])
        {
            selectButton[3].SetActive(false);
        }
        else
        {
            selectButton[3].SetActive(true);
        }

        if (isSelect[4])
        {
            selectButton[4].SetActive(false);
        }
        else
        {
            selectButton[4].SetActive(true);
        }

        if (isSelect[5])
        {
            selectButton[5].SetActive(false);
        }
        else
        {
            selectButton[5].SetActive(true);
        }

        if (isSelect[6])
        {
            selectButton[6].SetActive(false);
        }
        else
        {
            selectButton[6].SetActive(true);
        }
    }
    //�L�����N�^�[�I�����ʂɃV�[���ړ����鏈��
     private void clickButton()
    {
        if (!isSelect[0]  && !isSelect[6])
        {
            SceneManager.LoadScene("ResultScene");
        }
        else if (!isSelect[1] && !isSelect[6])
        {
            SceneManager.LoadScene("ResultScene2");
        }
        else if (!isSelect[2] && !isSelect[6])
        {
            SceneManager.LoadScene("ResultScene3");
        }
        else if(!isSelect[3] && !isSelect[6])
        {
            SceneManager.LoadScene("ResultScene4");
        }
        else if (!isSelect[4] && !isSelect[6])
        {
            SceneManager.LoadScene("ResultScene");
        }
        else if(!isSelect[5] && !isSelect[6])
        {
            SceneManager.LoadScene("ResultScene2");
        }      
    }

}
