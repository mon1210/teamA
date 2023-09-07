using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectionUI : MonoBehaviour
{
    /// <summary>
    /// ���������A�܂ق��A�Ђ�����I�𒆂��𔻒f�A�F�ύX
    /// </summary>

    //�擾�����q�v�f��SelectableText�̐����o��
    SelectableText[] selectableTexts;


    //�I������Ă���v�f�̃C���f�b�N�X
    int selectedIndex;//0:���������A1:�܂ق��A2:�Ђ�����

    //selectedIndex���擾�ł���悤��
    public int SelectedIndex { get => selectedIndex; }


    //�����Ɋ܂܂�Ă���q�v�f���擾����֐�
    public void Init()
    {
        //�q�v�f��SelectableText���擾
        selectableTexts = GetComponentsInChildren<SelectableText>();
    }


    //�I�𒆂̃e�L�X�g�̐F��ύX����֐�
    public void ChangeTextColor()
    {
        //����͂ŏ�̃e�L�X�g�I��
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            selectedIndex--;
        }
        //�����͂ŉ��̃e�L�X�g�I��
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
        }

        //index���e�L�X�g���𒴂��Ȃ��悤��
        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Length - 1);

        //�I������Ă���e�L�X�g�̐F�ύX
        for(int i = 0; i < selectableTexts.Length; i++)
        {
            if(selectedIndex==i)
            {
                selectableTexts[i].SetSelectedColor(true);
            }
            else
            {
                selectableTexts[i].SetSelectedColor(false);
            }

        }
    }

    //UI��\�����邽�߂̊֐�
    public void OpenSelectionUI()
    {
        //0�ɏ�����
        selectedIndex = 0;
        //UI��\��
        gameObject.SetActive(true);

    }
    //UI����邽�߂̊֐�
    public void CloseSelectionUI()
    {
        //0�ɏ�����
        selectedIndex = 0;
        //UI�����
        gameObject.SetActive(false);

    }
}