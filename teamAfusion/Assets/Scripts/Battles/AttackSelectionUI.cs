using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectionUI : MonoBehaviour
{
    //わざリストの位置情報の取得
    [SerializeField] RectTransform movesParent;
    //テキストPrefabの取得
    [SerializeField] SelectableText moveTextPrefab;
    //子要素のSelectableTextをリスト化
    List<SelectableText> selectableTexts = new List<SelectableText>();


    //選択されている要素のインデックス
    int selectedIndex;

    //selectedIndexを取得できるように
    public int SelectedIndex { get => selectedIndex; }



    //自分に含まれている子要素を取得する関数
    public void Init(List<Move> moves)
    {
        //子要素のSelectableTextを取得     prefab生成前に取得しようとする
        //selectableTexts = GetComponentsInChildren<SelectableText>();
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

        //リストの数分テキストprefabをループ生成
        for(int i = 0; i < moves.Count; i++)
        {
            //わざprefabを生成
            SelectableText moveText = Instantiate(moveTextPrefab, movesParent);
            //テキストに技名をセット
            moveText.SetMoveName(moves[i].Base.Name);
            //selectableTextに生成したわざprefabを追加
            selectableTexts.Add(moveText);

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
        selectedIndex = Mathf.Clamp(selectedIndex, 0, selectableTexts.Count - 1);

        //選択されているテキストの色変更
        for (int i = 0; i < selectableTexts.Count; i++)
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
