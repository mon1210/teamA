using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    //
    [SerializeField] ActionSelectionUI actionSelectionUI;

    enum Phase
    {
        Start,
        ActionSelection,
        AttackSelection,
        MagicSelection,
        BattleOver,
    }
    Phase phase = Phase.Start;

    // Start is called before the first frame update
    void Start()
    {
        actionSelection();
        //�q�v�f��SelectableText���擾����֐��̌Ăяo��
        actionSelectionUI.Init();
    }

    // Update is called once per frame
    void Update()
    {
        processBattlePhase();
    }

    private void processBattlePhase()
    {
        switch (phase)
        {
            case Phase.Start:
                break;
            case Phase.ActionSelection:
                handleActionSelection();
                break;
            case Phase.AttackSelection:
                handleAttackSelection();
                break;
            case Phase.MagicSelection:
                handleMagicSelection();
                break;
            case Phase.BattleOver:
                break;
            default:
                break;
        }
    }
    private void actionSelection()
    {
        //phase���o�g���A�N�V������
        phase = Phase.ActionSelection;
        //�A�N�V�����Z���N�V����UI��\��
        actionSelectionUI.OpenActionSelectionUI();
    }

    private void handleActionSelection()
    {
        //�I���������̂̃e�L�X�g�F�ύX
        actionSelectionUI.ChangeTextColor();

        //
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (actionSelectionUI.SelectedIndex == 0)
            {
                Debug.Log("��������");
            }
            else if (actionSelectionUI.SelectedIndex == 1)
            {
                Debug.Log("�܂ق�");
            }
            else
            {
                Debug.Log("�Ђ�����");
            }
        }
    }
    private void handleAttackSelection()
    {

    }
    private void handleMagicSelection()
    {


    }
}

