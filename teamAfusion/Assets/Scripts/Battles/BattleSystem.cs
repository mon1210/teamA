using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //player���̎擾
    [SerializeField] BattleUnit playerUnit;
    //enemy���̎擾
    [SerializeField] BattleUnit enemyUnit;
    //fade�ɕK�v�ȑf�ނ̎擾
    [SerializeField] Fade fade;

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

    //�o�g���J�n������
    public void BattleStart(Battler player, Battler enemy)
    {
        //����������
        phase = Phase.Start;
        //�f�o�b�O
        Debug.Log("�o�g���J�n");

        //�q�v�f��SelectableText���擾����֐��̌Ăяo��
        actionSelectionUI.Init();
        attackSelectionUI.Init(player.Moves);
        magicSelectionUI.Init();
        ultimateSelectionUI.Init();

        actionSelectionUI.CloseSelectionUI();
        //�o�g���O��SetUp
        StartCoroutine(setupBattle(player, enemy));
    }

    //�_�C�A���O�̃^�C�v���I�������A�N�V�����Z���N�V������
    private IEnumerator setupBattle(Battler player, Battler enemy)
    {
        //Unit�Ɋ�{�����Z�b�g
        playerUnit.Setup(player);
        enemyUnit.Setup(enemy);
        //�\��������܂őҋ@
        yield return battleDialog.TypeDialog($"{enemy.Base.Name}�����ꂽ�I\n�ǂ�����H");
        //�A�N�V�����Z���N�V������p�ӂ���֐��̌Ăяo��
        actionSelection();

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
            attackMove();
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
    //������������
    private void attackMove()
    {
        //�^�[������
        StartCoroutine(runTurns());

        //�s�����UI�����
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


    //���݂��̋Z����������u1�^�[���v�̓���
    private IEnumerator runTurns()
    {
        //phase�ύX
        phase = Phase.RunTurns;

        //plyermove�ɂ킴(�I�𒆂�Index)����
        Move playerMove = playerUnit.Battler.Moves[attackSelectionUI.SelectedIndex];
        //�����̍U��
        yield return runMove(playerMove,playerUnit, enemyUnit);
        //��������
        if(phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{enemyUnit.Battler.Base.Name}�����������I");
            yield break;
        }

        //enemymove�Ƀ����_���Ɉ�킴����
        Move enemyMove = enemyUnit.Battler.GetRondomMove();
        //�G�̍U��
        yield return runMove(enemyMove,enemyUnit, playerUnit);
        //�s�k����
        if (phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}�͖ڂ̑O���܂�����ɂȂ����I", auto: false);
            phase = Phase.GameOver;
            if (phase == Phase.GameOver)
            {
                OnNextScene();
            }
            yield break;
        }

        //�^�[���I�����_�C�A���O
        yield return battleDialog.TypeDialog("�ǂ�����H");
        //�A�N�V�����Z���N�V�����֖߂�
        actionSelection();
    }

    //���݂��̋Z�ɂ��_�C�A���O
    private IEnumerator runMove(Move move, BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int�^�Ŏ󂯎�����_���[�W���Z�b�g
        int damage = targetUnit.Battler.TakeDamage(move, sourcerUnit.Battler);
        //�_���[�W��^�����E�󂯂����O��\��
        yield return battleDialog.TypeDialog($"{sourcerUnit.Battler.Base.Name}��{move.Base.Name}�I\n{targetUnit.Battler.Base.Name}��{damage}�̃_���[�W�I", auto: false);
        //�_���[�W������UI�X�V
        targetUnit.UpdateUI();
        //��_���[�W�҂�HP0�ȉ���Phase�؂�ւ�
        if (targetUnit.Battler.HP <= 0) 
        {
            phase = Phase.BattleOver;
        }
    }
    //2�b�����ăt�F�[�h�A�E�g���ăV�[���؂�ւ�
    private void OnNextScene()
    {
        fade.FadeIn(2.0f, () => SceneManager.LoadScene("TitleScene"));
    }
}

