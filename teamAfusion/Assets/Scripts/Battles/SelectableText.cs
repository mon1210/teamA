using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableText : MonoBehaviour
{
    //�e�L�X�g���擾�p�̕ϐ��錾
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        //�e�L�X�g���擾
        text = GetComponent<Text>();
    }

    //�w�肳�ꂽ�e�L�X�g�̐F�ύX
    public void SetSelectedColor(bool selected)
    {
        //�I�𒆂Ȃ物�F(�����łȂ��Ȕ�)
        text.color = selected ? Color.yellow : Color.white;
        
    }

    //�����̖��O���e�L�X�g�ɑ��
    public void SetMoveName(string newName)
    {
        //Start���Instantiate�̂ق����������s�����̂ł��ꂪ�Ȃ���NULLReference�ɂȂ�
        if (text == null) 
        {
            text = GetComponent<Text>();
        }

        text.text = newName;
    }

}
