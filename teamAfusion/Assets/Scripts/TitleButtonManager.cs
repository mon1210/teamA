using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonManager : MonoBehaviour
{
    //ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½‚çTitleScene‚ÉˆÚ“®
    public void onClick()
    {
        SceneManager.LoadScene("TitleScene");
        
    }

}
