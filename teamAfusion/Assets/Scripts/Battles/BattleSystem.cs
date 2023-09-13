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
    //
    [SerializeField] private string nextSceneName;
    //
    [SerializeField] private string gameoverScene;

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
        attackSelectionUI.Init(player.AttackMoves);
        magicSelectionUI.Init(player.MagicMoves);
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
            magicMove();
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
            ultimateMove();
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
        StartCoroutine(attackRunTurns());

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
    private void magicMove()
    {
        //�^�[������
        StartCoroutine(magicRunTurns());
        //�s�����UI�����
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
    private void ultimateMove()
    {   
        //�^�[������
        //StartCoroutine(runTurns());

        //�s�����UI�����
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


    //���݂��̋Z����������u1�^�[���v�̓���
    private IEnumerator attackRunTurns()
    {
        //phase�ύX
        phase = Phase.RunTurns;

        //plyermove�ɂ킴(�I�𒆂�Index)����
        Move playerMove = playerUnit.Battler.AttackMoves[attackSelectionUI.SelectedIndex];
        //�����̍U��
        yield return runMove(playerMove,playerUnit, enemyUnit);
        //��������
        if(phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{enemyUnit.Battler.Base.Name}�����������I");
            onNextScene(nextSceneName);
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
                onNextScene(gameoverScene);
            }
            yield break;
        }

        //�^�[���I�����_�C�A���O
        yield return battleDialog.TypeDialog("�ǂ�����H");
        //�A�N�V�����Z���N�V�����֖߂�
        actionSelection();
    }
    private IEnumerator magicRunTurns()
    {
        //phase�ύX
        phase = Phase.RunTurns;

        //plyermove�ɂ킴(�I�𒆂�Index)����
        Move playerMove = playerUnit.Battler.MagicMoves[magicSelectionUI.SelectedIndex];
        //�����̍U��
        yield return runMove(playerMove, playerUnit, enemyUnit);
        //��������
        if (phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{enemyUnit.Battler.Base.Name}�����������I");
            onNextScene(nextSceneName);
            yield break;
        }

        //enemymove�Ƀ����_���Ɉ�킴����
        Move enemyMove = enemyUnit.Battler.GetRondomMove();
        //�G�̍U��
        yield return runMove(enemyMove, enemyUnit, playerUnit);
        //�s�k����
        if (phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}�͖ڂ̑O���܂�����ɂȂ����I", auto: false);
            phase = Phase.GameOver;
            if (phase == Phase.GameOver)
            {
                onNextScene(gameoverScene);
            }
            yield break;
        }

        //�^�[���I�����_�C�A���O
        yield return battleDialog.TypeDialog("�ǂ�����H");
        //�A�N�V�����Z���N�V�����֖߂�
        actionSelection();
    }

    //���݂��̋Z�ɂ��_�C�A���O
    private IEnumerator runMove(Move move, BattleUnit sourceUnit, BattleUnit targetUnit)
    {
        //�󂯎�����s���̃e�L�X�g����
        string resultText = move.Base.RunMoveResult(sourceUnit, targetUnit);
        //�s���̃e�L�X�g��\��
        yield return battleDialog.TypeDialog(resultText, auto: false);
        //��_���[�W�����ɂ��UI�X�V
        targetUnit.UpdateUI();
        //�Z�g�p�҂�UI�X�V(HP�񕜎��Ɏg�p)
        sourceUnit.UpdateUI();
        //��_���[�W�҂�HP0�ȉ���Phase�؂�ւ�
        if (targetUnit.Battler.HP <= 0) 
        {
            phase = Phase.BattleOver;
        }
    }
    //2�b�����ăt�F�[�h�A�E�g���ăV�[���؂�ւ�
    private void onNextScene(string sceneName)
    {
        fade.FadeIn(2.0f, () => SceneManager.LoadScene(sceneName));
    }
}

