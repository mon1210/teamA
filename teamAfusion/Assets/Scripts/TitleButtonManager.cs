using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonManager : MonoBehaviour
{
   
    //ボタンを押したらTitleSceneに移動
    public void OnClick()
    {
        SceneManager.LoadScene("TitleScene");       
    }

}