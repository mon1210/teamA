using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonManager : MonoBehaviour
{
    //�{�^������������TitleScene�Ɉړ�
    public void onClick()
    {
        SceneManager.LoadScene("TitleScene");
        
    }

}
