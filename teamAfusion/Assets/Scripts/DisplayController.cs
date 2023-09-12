using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController : MonoBehaviour
{
    //�I����Ԏ擾
    [SerializeField] bool[] isSelect = new bool[1];

    //�\���Ɋւ��鏈��
    public void OnDisplayButton()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("BattleScene1-1");
    }
    public void OnDisplayButton02()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("BattleScene1-2");
    }
    public void OnDisplayButton03()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("BattleScene1-3");
    }
}
