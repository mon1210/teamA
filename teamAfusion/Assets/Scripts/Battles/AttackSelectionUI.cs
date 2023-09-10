using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectionUI : MonoBehaviour
{
    //
    [SerializeField] RectTransform movesParent;
    //
    [SerializeField] SelectableText moveTextPrefab;
    //取得した子要素のSelectableTextの数を出す
    [SerializeField] SelectableText[] selectableTexts;


    //選択されている要素のインデックス
    int selectedIndex;

    //selectedIndexを取得できるように
    public int SelectedIndex { get => selectedIndex; }


    //自分に含まれている子要素を取得する関数
    public void Init(List<Move> moves)
    {
        //子要素のSelectableTextを取得
        selectableTexts = GetComponentsInChildren<SelectableText>();
        setUISize(moves);
    }

    //技の数に合わせてUIのサイズを変える関数
    private void setUISize(List<Move> moves)
    {
        Vector2 uiSize = movesParent.sizeDelta;
        //UIのサイズをy方向(下)に50+100*技の数分伸ばす
        uiSize.y = 50 + 100 * moves.Count;
        //再代入
        movesParent.sizeDelta = uiSize;
        //リストの数分テキストprefabを生成
        for(int i = 0; i < moves.Count; i++)
        {
            SelectableText moveText = Instantiate(moveTextPrefab, movesParent);
            moveText.SetMoveName(moves[i].Base.Name);
        }
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

    //UIを表示するための関数
    public void OpenSelectionUI()
    {
        //0に初期化
        selectedIndex = 0;
        //UIを表示
        gameObject.SetActive(true);

    }
    //UIを閉じるための関数
    public void CloseSelectionUI()
    {
        //0に初期化
        selectedIndex = 0;
        //UIを閉じる
        gameObject.SetActive(false);

    }
}
