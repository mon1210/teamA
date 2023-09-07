using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{ 
    //�A�N�V�����Z���N�V����UI�̎擾
    [SerializeField] ActionSelectionUI actionSelectionUI;
    //���������I��UI�̎擾
    [SerializeField] AttackSelectionUI attackSelectionUI;
    //�܂ق��I��UI�̎擾
    [SerializeField] MagicSelectionUI magicSelectionUI;
    //�Ђ����I��UI�̎擾
    [SerializeField] UltimateSelectionUI ultimateSelectionUI;
    //�_�C�A���O�̎擾
    [SerializeField] BattleDialog battleDialog;
    //
    [SerializeField] BattleUnit playerUnit;
    //
    [SerializeField] BattleUnit enemyUnit;
    //
    [SerializeField] GameObject fadePanel;
    //
    private FadeOutManager fadePanelScript;
    //phase�����̕ϐ��錾
    enum Phase
    {
        Start,
        ActionSelection,
        AttackSelection,
        MagicSelection,
        UltimateSelection,
        RunTurns,
        BattleOver,
        GameOver,
    }
    //Phase�^�̕ϐ��錾
    Phase phase;

    // Start is called before the first frame update
    public void BattleStart(Battler player, Battler enemy)
    {
        //����������
        phase = Phase.Start;
        //�f�o�b�O
        Debug.Log("�o�g���J�n");

        //�q�v�f��SelectableText���擾����֐��̌Ăяo��
        actionSelectionUI.Init();
        attackSelectionUI.Init();
        magicSelectionUI.Init();
        ultimateSelectionUI.Init();

        actionSelectionUI.CloseSelectionUI();
        //
        StartCoroutine(setupBattle(player, enemy));
    }

    //�_�C�A���O�̃^�C�v���I�������A�N�V�����Z���N�V������
    private IEnumerator setupBattle(Battler player, Battler enemy)
    {
        playerUnit.Setup(player);
        enemyUnit.Setup(enemy);
        //�\��������܂őҋ@
        yield return battleDialog.TypeDialog($"{enemy.Base.Name}�����ꂽ�I\n�ǂ�����H");
        //�A�N�V�����Z���N�V������p�ӂ���֐��̌Ăяo��
        actionSelection();

    }
    void Start()
    {
        fadePanelScript = fadePanel.GetComponent<FadeOutManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //ActionSelectionUI��\��
        processBattlePhase();
    }

    //Phase�̏�������
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

        //�s�����UI�����
        attackSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());

    }
    //��ڂ̂�����������
    private void attackMove2()
    {
        Debug.Log("�悭�˂炤");

        //�s�����UI�����
        attackSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());

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

        //�s�����UI�����
        magicSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());

    }
    //��ڂ̂܂ق�����
    private void magicMove2()
    {
        Debug.Log("������");
        
        //�s�����UI�����
        magicSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());

    }
    //�O�ڂ̂܂ق�����
    private void magicMove3()
    {
        Debug.Log("���݂Ȃ�");

        //�s�����UI�����
        magicSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());

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

        //�s�����UI�����
        ultimateSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());
    }
    //��ڂ̂Ђ�������
    private void ultimateMove2()
    {
        Debug.Log("�����ǂ͂��");

        //�s�����UI�����
        ultimateSelectionUI.CloseSelectionUI();

        //�^�[������
        StartCoroutine(runTurns());
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
    private IEnumerator runTurns()
    {
        //phase�ύX
        phase = Phase.RunTurns;
        //
        yield return runMove(playerUnit, enemyUnit);
        //
        if(phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{enemyUnit.Battler.Base.Name}�����������I");
            yield break;
        }
        //
        yield return runMove(enemyUnit, playerUnit);
        //
        if (phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}�͖ڂ̑O���܂�����ɂȂ����I");
            phase = Phase.GameOver;
            if (phase == Phase.GameOver)
            {
                fadePanelScript.FadeOut(true);
            }
            yield break;
        }
        //
        yield return battleDialog.TypeDialog("�ǂ�����H");
        //�A�N�V�����Z���N�V�����֖߂�
        actionSelection();
    }

    private IEnumerator runMove(BattleUnit sourcerUnit,BattleUnit targetUnit)
    {
        //int�^�Ŏ󂯎�����_���[�W���Z�b�g
        int damage = targetUnit.Battler.TakeDamage(sourcerUnit.Battler);
        //�_���[�W��^�����E�󂯂����O��\��
        yield return battleDialog.TypeDialog($"{sourcerUnit.Battler.Base.Name}�̂��������I\n{targetUnit.Battler.Base.Name}��{damage}�̃_���[�W�I", auto: false);
        //�_���[�W������UI�X�V
        targetUnit.UpdateUI();
        //
        if (targetUnit.Battler.HP <= 0) 
        {
            phase = Phase.BattleOver;
        }
    }
}
