using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonController : MonoBehaviour
{
    //�I����Ԏ擾
    [SerializeField] bool[] isSelect = new bool[1];

    //�X�^�[�g�{�^���̊֐�
    public void OnStartButton()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("ChoiceScene");
    }


}
