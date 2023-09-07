using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{ 
    //
    [SerializeField] ActionSelectionUI actionSelectionUI;
    //
    [SerializeField] AttackSelectionUI attackSelectionUI;
    //
    [SerializeField] MagicSelectionUI magicSelectionUI;
    //
    [SerializeField] UltimateSelectionUI ultimateSelectionUI;

    enum Phase
    {
        Start,
        ActionSelection,
        AttackSelection,
        MagicSelection,
        UltimateSelection,
        RunTurns,
        BattleOver,
    }
    Phase phase = Phase.Start;

    // Start is called before the first frame update
    void Start()
    {
        actionSelection();
        //�q�v�f��SelectableText���擾����֐��̌Ăяo��
        actionSelectionUI.Init();
        //
        attackSelectionUI.Init();
        //
        magicSelectionUI.Init();
        //
        ultimateSelectionUI.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //ActionSelectionUI��\��
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
            case Phase.UltimateSelection:
                handleUltimateSelection();
                break;
            case Phase.BattleOver:
                break;
            default:
                break;
        }
    }

    //�A�N�V�����I���֐�
    private void handleActionSelection()
    {
        //�I���������̂̃e�L�X�g�F�ύX
        actionSelectionUI.ChangeTextColor();

        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (actionSelectionUI.SelectedIndex == 0)
            {
                attackSelection();
            }
            else if (actionSelectionUI.SelectedIndex == 1)
            {
                magicSelection();
            }
            else
            {
                ultimateSelection();
            }
        }
    }
    //���������I���֐�
    private void handleAttackSelection()
    {
        //�I���������̂̃e�L�X�g�F�ύX
        attackSelectionUI.ChangeTextColor();

        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attackSelectionUI.SelectedIndex == 0)
            {
                attackMove1();
            }
            else if (attackSelectionUI.SelectedIndex == 1)
            {
                attackMove2();
            }
            else
            {
                attackBack();
            }
        }
    }
    //�܂ق��I���֐�
    private void handleMagicSelection()
    {
        //�I���������̂̃e�L�X�g�F�ύX
        magicSelectionUI.ChangeTextColor();

        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (magicSelectionUI.SelectedIndex == 0)
            {
                magicMove1();
            }
            else if (magicSelectionUI.SelectedIndex == 1)
            {
                magicMove2();
            }
            else if(magicSelectionUI.SelectedIndex==2)
            {
                magicMove3();
            }
            else
            {
                magicBack();
            }
        }

    }
    //�Ђ����I���֐�
    private void handleUltimateSelection()
    {
        //�I���������̂̃e�L�X�g�F�ύX
        ultimateSelectionUI.ChangeTextColor();

        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ultimateSelectionUI.SelectedIndex == 0)
            {
                ultimateMove1();
            }
            else if (ultimateSelectionUI.SelectedIndex == 1)
            {
                ultimateMove2();
            }
            else
            {
                ultimateBack();
            }
        }

    }
    //�A�N�V�����I��UI�\���֐�
    private void actionSelection()
    {
        //phase���o�g���A�N�V������
        phase = Phase.ActionSelection;
        //�A�N�V�����Z���N�V����UI��\��
        actionSelectionUI.OpenSelectionUI();
    }

    /********************** �������� *************************/
    //���������I��UI�\���֐�
    private void attackSelection()
    {
        //
        phase = Phase.AttackSelection;
        //
        attackSelectionUI.OpenSelectionUI();
    }
    //��ڂ̂�����������
    private void attackMove1()
    {
        Debug.Log("�Ԃ�܂킷");
        runTurns();
        attackSelectionUI.CloseSelectionUI();

    }
    //��ڂ̂�����������
    private void attackMove2()
    {
        Debug.Log("�悭�˂炤");
        runTurns();
        attackSelectionUI.CloseSelectionUI();
    }
    //���ǂ�
    private void attackBack()
    {
        //
        phase = Phase.ActionSelection;
        //
        attackSelectionUI.CloseSelectionUI();
    }
    /********************** �܂ق� *************************/
    //�܂ق��I��UI�\���֐�
    private void magicSelection()
    {
        //
        phase = Phase.MagicSelection;
        //
        magicSelectionUI.OpenSelectionUI();
    }
    //��ڂ̂܂ق�����
    private void magicMove1()
    {
        Debug.Log("�ق̂�");
        runTurns();
        magicSelectionUI.CloseSelectionUI();
    }
    //��ڂ̂܂ق�����
    private void magicMove2()
    {
        Debug.Log("������");
        runTurns();
        magicSelectionUI.CloseSelectionUI();
    }
    //�O�ڂ̂܂ق�����
    private void magicMove3()
    {
        Debug.Log("���݂Ȃ�");
        runTurns();
        magicSelectionUI.CloseSelectionUI();
    }
    //���ǂ�
    private void magicBack()
    {
        //
        phase = Phase.ActionSelection;
        //
        magicSelectionUI.CloseSelectionUI();
    }

    /********************** �Ђ����� *************************/
    //�Ђ����I��UI�\���֐�
    private void ultimateSelection()
    {
        //
        phase = Phase.UltimateSelection;
        //
        ultimateSelectionUI.OpenSelectionUI();
    }
    //��ڂ̂Ђ�������
    private void ultimateMove1()
    {
        Debug.Log("�����Ă��؂񂬂�");
        runTurns();
        ultimateSelectionUI.CloseSelectionUI();
    }
    //��ڂ̂Ђ�������
    private void ultimateMove2()
    {
        Debug.Log("�����ǂ͂��");
        runTurns();
        ultimateSelectionUI.CloseSelectionUI();
    }
    //���ǂ�
    private void ultimateBack()
    {
        //
        phase = Phase.ActionSelection;
        //
        ultimateSelectionUI.CloseSelectionUI();
    }

    //
    private void runTurns()
    {
        phase = Phase.RunTurns;
        Debug.Log("���҂̍U������");
        actionSelection();
    }

}

