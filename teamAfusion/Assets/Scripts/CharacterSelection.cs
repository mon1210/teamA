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
    [SerializeField] GameObject[] selectButton = new GameObject[6];
    //�I����Ԏ擾
    [SerializeField] bool[] isSelect;
    [SerializeField] bool[] isSelected;
    //�e�L�X�g�擾
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < selectButton.Length; i++)
        {
            //�{�^���̑I����S�Ď�����
            isSelect[i] = false;
            isSelected[i] = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //�g�̕\���؂�ւ�
        selectChecker();
        clickButton();
    }
    //�I���{�^���̏���
   public void OnSelectButton()
   {     
       //�N���b�N����邽�т�ON��OFF��؂�ւ���
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
    //�����{�^���̏���
    public void OnStartButton()
    {
        isSelected[0] = !isSelected[0];
    }
        //�I������Ă��邩�ǂ����̏���
   private void selectChecker()
   {
      for (int i = 0; i < selectButton.Length; i++) 
      {
            //�g���\��
          if (isSelect[i]== true)
          {
              selectButton[i].SetActive(true);
          }
          //�g��\��
          else
          {
              selectButton[i].SetActive(false);
          }
      }

   }
    //�L�����N�^�[�I�����ʂɃV�[���ړ����鏈��
    private void clickButton()
    {
            if (isSelect[0] == true && isSelected[0]==false)
            {
                SceneManager.LoadScene("FirstSynthesisScene");
            }
            else if (isSelect[1] == true && isSelected[0]==false)
            {
                SceneManager.LoadScene("FirstSynthesisScene");
            }
            else if (isSelect[2] == true && isSelected[0] == false)
            {
                SceneManager.LoadScene("SecondSynthesisScene");
            }
            else if (isSelect[3] == true && isSelected[0]==false)
            {
                SceneManager.LoadScene("ThirdSynthesisScene");
            }
            else if (isSelect[4] == true && isSelected[0] == false)
            {
                SceneManager.LoadScene("SecondSynthesisScene");
            }
            else if (isSelect[5] == true && isSelected[0] == true)
            {
                SceneManager.LoadScene("SecondSynthesisScene");
            }

    }

}