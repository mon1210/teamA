using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController1 : MonoBehaviour
{
    //表示に関する処理
    public void OnMagicDisplayButton1()
    {
        SceneManager.LoadScene("M.FirstBattleScene");
    }
    public void OnMagicDisplayButton2()
    {
        SceneManager.LoadScene("M.SecondBattleScene");
    }
    public void OnMagicDisplayButton3()
    {
        SceneManager.LoadScene("M.ThirdBattleScene");
    }
}
