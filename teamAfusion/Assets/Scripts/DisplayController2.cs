using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController2: MonoBehaviour
{
    //�\���Ɋւ��鏈��
    public void OnBanlceDisplayButton1()
    {
        SceneManager.LoadScene("B.FirstBattleScene");
    }
    public void OnBanlceDisplayButtonn2()
    {
        SceneManager.LoadScene("B.SecondBattleScene");
    }
    public void OnBanlceDisplayButton3()
    {
        SceneManager.LoadScene("B.ThirdtBattleScene");
    }
}
