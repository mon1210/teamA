using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChoiceButtonController : MonoBehaviour
{   
    //選択状態取得
    [SerializeField] bool[] isSelect = new bool[1];

    //スタートボタンの関数
    public void OnChoiceButton()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("BoosDisplayScene");
    }


}
