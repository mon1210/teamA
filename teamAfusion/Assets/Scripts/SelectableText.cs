using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableText : MonoBehaviour
{
    //テキストを取得用の変数宣言
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        //テキストを取得
        text = GetComponent<Text>();
    }

    //指定されたテキストの色変更
    public void SetSelectedColor(bool selected)
    {
        //選択中なら黄色
        if(selected)
        {
            text.color = Color.yellow;
        }
        //そうでなければ白
        else
        {
            text.color = Color.white;
        }
    }
}
