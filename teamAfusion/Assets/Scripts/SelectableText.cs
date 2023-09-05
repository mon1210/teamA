using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableText : MonoBehaviour
{
    /// <summary>
    /// Textの色変更
    /// 選択中なら色を黄色に
    /// </summary>
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        //テキストを取得
        text = GetComponent<Text>();
    }

    //指定されたテキストの色変更
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
