using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChoiceButtonController : MonoBehaviour
{  
    //スタートボタンの関数
    public void OnChoiceButton()
    {
        SceneManager.LoadScene("M.BossDisplayScene");
    }
    public void OnChoiceButton2()
    {
        SceneManager.LoadScene("A.BossDisplayScene");
    }
    public void OnChoiceButton3()
    {
        SceneManager.LoadScene("B.BossDisplayScene");
    }


}
