using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterSelection: MonoBehaviour
{
    //�I���{�^���̎擾
    [SerializeField] GameObject[] selectButton = new GameObject[6];
    //�I����Ԏ擾
    [SerializeField] bool[] isSelect;
    //�e�L�X�g�擾
    [SerializeField] Text text;

    [SerializeField] private string[] sceneName;

    [SerializeField] private Button[] startButton;

    [SerializeField] private Button[] Button;

    private EventTrigger[] trigger;

    // Start is called before the first frame update
    void Start()
    {
        eventTrigger();
        sceneName = new string[selectButton.Length];
        isSelect = new bool[selectButton.Length];
        

        for (int i = 0; i < selectButton.Length; i++)
        {
            //�{�^���̑I����S�Ď�����
            isSelect[i] = false;
        }
        buttonCilcEvet();
        
    }
    private void eventTrigger()
    {
        for (int i = 0; i < selectButton.Length; i++)
        {
            trigger[i] = selectButton[i].GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((enentDate) => { Debug.Log("������"); });
            trigger[i].triggers.Add(entry);
        }
    }

    private void buttonCilcEvet()
    {
        for (int i = 0; i < Button.Length; i++)
            Button[i].onClick.AddListener(() => changSelectFlag(i));
        for (int i = 0; i < startButton.Length; i++)
            startButton[i].onClick.AddListener(() => clickButton());
    }


    private void changSelectFlag(int i)
    {
        //�N���b�N����邽�т�ON��OFF��؂�ւ���
        isSelect[i] = !isSelect[i];
        selectButton[i].SetActive(isSelect[i]);
        Debug.Log("�����ꂽ");

    }

   
    
    //�L�����N�^�[�I�����ʂɃV�[���ړ����鏈��
     private void clickButton()
    {
        for(int i= 0;i<isSelect.Length;i++)
        {
            if (isSelect[i])
            {
                SceneManager.LoadScene(sceneName[i]);
            }
        }
    }

}
