using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSelectionUI : MonoBehaviour
{
    //取得した子要素のSelectableTextの数を出す
    SelectableText[] selectableTexts;


    int selectedIndex;

    //selectedIndexを取得できるように
    public int SelectedIndex { get => selectedIndex; }

    // Update is called once per frame
    void Update()
    {
        //選択中のテキストの色変更
        //ChangeTextColor();
    }

    public void Init()
    {
        //子要素のSelectableTextを取得
        selectableTexts = GetComponentsInChildren<SelectableText>();
    }

    //選択中のテキストの色を変更する関数
    public void ChangeTextColor()
    {
        //上入力で上のテキスト選択
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
        }
        //下入力で下のテキスト選択
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
        }

        //indexがテキスト数を超えないように
        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Length - 1);

        //選択されているテキストの色変更
        for (int i = 0; i < selectableTexts.Length; i++)
        {
            if (selectedIndex == i)
            {
                selectableTexts[i].SetSelectedColor(true);
            }
            else
            {
                selectableTexts[i].SetSelectedColor(false);
            }

        }
    }

    public void OpenSelectionUI()
    {
        //0に初期化
        selectedIndex = 0;
        //
        gameObject.SetActive(true);

    }
    public void CloseSelectionUI()
    {
        //0に初期化
        selectedIndex = 0;
        //
        gameObject.SetActive(false);

    }
}
