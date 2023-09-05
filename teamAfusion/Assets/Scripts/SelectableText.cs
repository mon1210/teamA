using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableText : MonoBehaviour
{
    /// <summary>
    /// Text�̐F�ύX
    /// �I�𒆂Ȃ�F�����F��
    /// </summary>
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        //�e�L�X�g���擾
        text = GetComponent<Text>();
    }

    //�w�肳�ꂽ�e�L�X�g�̐F�ύX
    public void SetSelectedColor(bool selected)
    {
        if(selected)
        {
            text.color = Color.yellow;
        }
        else
        {
            text.color = Color.white;
        }
    }
}
