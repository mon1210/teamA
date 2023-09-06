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

    public void StopGame()
    {
        Time.timeScale = 0f;
        itemButton.SetActive(false);
        reStartButton.SetActive(true);
        itemPanel.SetActive(true);
    }

    public void ReStartGame()
    {
        itemPanel.SetActive(false);
        reStartButton.SetActive(false);
        itemButton.SetActive(true);
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
