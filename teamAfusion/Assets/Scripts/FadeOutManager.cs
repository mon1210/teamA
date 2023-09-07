using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutManager : MonoBehaviour
{    
    //
    [SerializeField] GameObject fadePanel;
    //フェードパネルのイメージ取得変数
    Image fadealpha;
    //パネルのalpha値取得変数
    private float alpha;
    //フェードアウトのフラグ変数
    private bool fadeout;
    //シーンの移動先ナンバー取得変数
    public int SceneNo;
    // Use this for initialization
    void Start()
    {
        //パネルのイメージ取得
        fadealpha = fadePanel.GetComponent<Image>();
        //パネルのalpha値を取得
        alpha = fadealpha.color.a;

    }

    public void FadeOut(bool fadeout)
    {
        if(fadeout == true)
        {
            alpha += 0.01f;
            fadealpha.color = new Color(0, 0, 0, alpha);
            if (alpha >= 1)
            {
                fadeout = false;
            }
        }
        
    }

}
