using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController : MonoBehaviour
{
    //‘I‘ğó‘Ôæ“¾
    [SerializeField] bool[] isSelect = new bool[1];

    //•\¦‚ÉŠÖ‚·‚éˆ—
    public void OnDisplayButton()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("FirstBattleScene");
    }
    public void OnDisplayButton02()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("SecondBattleScene");
    }
    public void OnDisplayButton03()
    {
        isSelect[0] = !isSelect[0];

        SceneManager.LoadScene("LastBattleScene");
    }
}
