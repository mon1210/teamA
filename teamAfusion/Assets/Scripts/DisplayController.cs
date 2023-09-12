using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController : MonoBehaviour
{
    //選択状態取得
    [SerializeField] bool[] isSelect = new bool[1];

    //表示に関する処理
    public void OnDisplayButton()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("FirstBattleScene");
    }
    public void OnDisplayButton02()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("SecondBattleSceneLastBattleeScene");
    }
    public void OnDisplayButton03()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("LastBattleeScene");
    }
}
