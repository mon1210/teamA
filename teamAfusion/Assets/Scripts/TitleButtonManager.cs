using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonManager : MonoBehaviour
{
    //ボタンを押したらTitleSceneに移動
    public void onClick()
    {
        SceneManager.LoadScene("TitleScene");
        
    }

}
