using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager2 : MonoBehaviour
{
    //�@�A�C�e�����j���[���J���{�^��
    [SerializeField]
    private GameObject itemButton;
    //�@�Q�[���ĊJ�{�^��
    [SerializeField]
    private GameObject reStartButton;
    //�@�A�C�e�����j���[�p�l��
    [SerializeField]
    private GameObject itemPanel;
    //�^�C�g���ɖ߂�{�^��
   

    public void stopGame()
    {
        //���Ԓ�~
        Time.timeScale = 0f;
        //itemButton��\��
        itemButton.SetActive(false);
        //reStartButton�\��
        reStartButton.SetActive(true);
        //itemPanel�\��
        itemPanel.SetActive(true);
        
    }

    public void reStartGame()
    {
        //itemPanel��\��
        itemPanel.SetActive(false);
        //reStartButton��\��
        reStartButton.SetActive(false);
        //itemButton�\��
        itemButton.SetActive(true);
        //���͓����o��
        Time.timeScale = 1f;
    }
    
}
