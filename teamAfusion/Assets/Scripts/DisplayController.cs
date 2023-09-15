using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController : MonoBehaviour
{
    //表示に関する処理
    public void OnAttackDisplayButton()
    {
        SceneManager.LoadScene("A.FirstBattleScene");
    }
    public void OnAttackDisplayButton2()
    {
        SceneManager.LoadScene("A.SecondBattleScene");
    }
    public void OnAttackDisplayButton3()
    {
        SceneManager.LoadScene("A.LastBattleScene");
    }
}
