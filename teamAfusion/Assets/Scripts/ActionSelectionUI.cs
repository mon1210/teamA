using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectionUI : MonoBehaviour
{
    /// <summary>
    /// こうげき、まほう、ひっさつを選択中かを判断、色変更
    /// </summary>
    
    //取得した子要素のSelectableTextの数を出す
    [SerializeField]SelectableText[] selectableTexts;

    int selectedIndex;//0:こうげき、1:まほう、2:ひっさつ
    // Start is called before the first frame update
    void Start()
    {
        //子要素のSelectableTextを取得する関数の呼び出し
        init();
    }

    // Update is called once per frame
    void Update()
    {
        //選択中のテキストの色変更
        changeTextColor();
    }

    private void init()
    {
        //子要素のSelectableTextを取得
        selectableTexts = GetComponentsInChildren<SelectableText>();
    }

    //選択中のテキストの色を変更する関数
    private void changeTextColor()
    {
        //上入力で上のテキスト選択
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            selectedIndex--;
        }
        //下入力で下のテキスト選択
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
        }

        //indexがテキスト数を超えないように
        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Length - 1);

        //選択されているテキストの色変更
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
