using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChoiceButtonController : MonoBehaviour
{  
    //�X�^�[�g�{�^���̊֐�
    public void OnChoiceButton()
    {
        SceneManager.LoadScene("BossDisplayScene");
    }


}
