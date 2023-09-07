using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
    //テキスト取得
    [SerializeField] private Text text;
    //何秒間隔で文字が表示されるかを決める
    [SerializeField] private float letterPerSecond;

    //0.1秒に1文字ずつ表示するようなコルーチン
    public IEnumerator TypeDialog(string line)
    {
        //テキストを空に
        text.text = "";

        //一文字ずつメッセージを表示
        foreach (char letter in line)
        {
            text.text += letter;

            yield return new WaitForSeconds(letterPerSecond);

        }
    }
}
