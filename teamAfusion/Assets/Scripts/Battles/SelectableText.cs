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
        //選択中なら黄色(そうでないな白)
        text.color = selected ? Color.yellow : Color.white;
        
    }

    //引数の名前をテキストに代入
    public void SetMoveName(string newName)
    {
        //StartよりInstantiateのほうが早く実行されるのでこれがないとNULLReferenceになる
        if (text == null) 
        {
            text = GetComponent<Text>();
        }

        text.text = newName;
    }

}
