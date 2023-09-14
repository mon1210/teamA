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
        SceneManager.LoadScene("BossDisplayScene");
    }


}
