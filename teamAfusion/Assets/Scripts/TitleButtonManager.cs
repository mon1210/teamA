using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonManager : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
        
    }

}
