using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutManager : MonoBehaviour
{    
    //
    [SerializeField] GameObject fadePanel;
    //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    Image fadealpha;
    //�p�l����alpha�l�擾�ϐ�
    private float alpha;
    //�t�F�[�h�A�E�g�̃t���O�ϐ�
    private bool fadeout;
    //�V�[���̈ړ���i���o�[�擾�ϐ�
    public int SceneNo;
    // Use this for initialization
    void Start()
    {
        //�p�l���̃C���[�W�擾
        fadealpha = fadePanel.GetComponent<Image>();
        //�p�l����alpha�l���擾
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
