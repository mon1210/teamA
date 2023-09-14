using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonController : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("タイトル");
       
    }
    //スタートボタンの関数
    public void OnClickStartButton()
    { 
        SceneManager.LoadScene("ChoiceScene");
    }
}
