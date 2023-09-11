using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    //�I���{�^���̎擾
    [SerializeField] GameObject[] Button = new GameObject[1];
    //�I����Ԏ擾
    [SerializeField] bool[] isSelect = new bool[1];
    //�e�L�X�g�擾
    [SerializeField] Text text;

    void Start()
    {
        onStartButton();
    }
    //�X�^�[�g�{�^���̊֐�
    private void onStartButton()
    {
        isSelect[0] =! isSelect[0];

        SceneManager.LoadScene("ChoiceScene");
    }
}
