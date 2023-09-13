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
    //�I���{�^���̎擾
    [SerializeField] GameObject[] selectButton = new GameObject[7];
    //�I����Ԏ擾
    [SerializeField] bool[] isSelect;
    //�e�L�X�g�擾
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
        for (int i = 0; i < selectButton.Length - 1; i++)
        {
            //�N���b�N����邽�т�ON��OFF��؂�ւ���
            isSelect[i] = !isSelect[i];
            Debug.Log("�����ꂽ");
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
    //�L�����N�^�[�I�����ʂɃV�[���ړ����鏈��
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