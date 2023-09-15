using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayController1 : MonoBehaviour
{
    //ï\é¶Ç…ä÷Ç∑ÇÈèàóù
    public void OnMagicDisplayButton1()
    {
        SceneManager.LoadScene("M.FirstBattleScene");
    }
    public void OnMagicDisplayButton2()
    {
        SceneManager.LoadScene("M.SecondBattleScene");
    }
    public void OnMagicDisplayButton3()
    {
        SceneManager.LoadScene("M.ThirdBattleScene");
    }
}
