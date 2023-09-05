using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectionUI : MonoBehaviour
{
    /// <summary>
    /// ���������A�܂ق��A�Ђ�����I�𒆂��𔻒f�A�F�ύX
    /// </summary>
    
    //�擾�����q�v�f��SelectableText�̐����o��
    [SerializeField]SelectableText[] selectableTexts;

    int selectedIndex;//0:���������A1:�܂ق��A2:�Ђ�����
    // Start is called before the first frame update
    void Start()
    {
        //�q�v�f��SelectableText���擾����֐��̌Ăяo��
        init();
    }

    // Update is called once per frame
    void Update()
    {
        //�I�𒆂̃e�L�X�g�̐F�ύX
        changeTextColor();
    }

    private void init()
    {
        //�q�v�f��SelectableText���擾
        selectableTexts = GetComponentsInChildren<SelectableText>();
    }

    //�I�𒆂̃e�L�X�g�̐F��ύX����֐�
    private void changeTextColor()
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
}