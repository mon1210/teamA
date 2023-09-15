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
    //�ړ���̃V�[�������擾
    [SerializeField] private string nextSceneName;
    //�Q�[���I�[�o�[���̃V�[�������擾
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

        //SoundManager.Instance.PlayBGM(BGMSoundData.BGM.FirstBattle);

        //�q�v�f��SelectableText���擾����֐��̌Ăяo��
        actionSelectionUI.Init();
        attackSelectionUI.Init(player.AttackMoves);
        magicSelectionUI.Init(player.MagicMoves);
        ultimateSelectionUI.Init(player.UltimateMoves);

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
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            closeSelectionUI(attackSelectionUI);
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
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeSelectionUI(magicSelectionUI);
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
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeSelectionUI(ultimateSelectionUI);
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
        //phase���o�g���A�N�V������
        phase = Phase.AttackSelection;
        //�A�N�V�����Z���N�V����UI��\��
        attackSelectionUI.OpenSelectionUI();
    }
    //������������
    private void attackMove()
    {
        //�^�[������   plyermove�ɂ킴(�I�𒆂�Index)����
        StartCoroutine(runTurns(playerUnit.Battler.AttackMoves[attackSelectionUI.SelectedIndex]));

        //�s�����UI�����
        attackSelectionUI.CloseSelectionUI(); 
    }

    /********************** �܂ق� *************************/
    //�܂ق��I��UI�\���֐�
    private void magicSelection()
    {
        //phase���o�g���A�N�V������
        phase = Phase.MagicSelection;
        //�A�N�V�����Z���N�V����UI��\��
        magicSelectionUI.OpenSelectionUI();
    }
    //�܂ق�����
    private void magicMove()
    {
        //�^�[������   plyermove�ɂ킴(�I�𒆂�Index)����
        StartCoroutine(runTurns(playerUnit.Battler.MagicMoves[magicSelectionUI.SelectedIndex]));
        //�s�����UI�����
        magicSelectionUI.CloseSelectionUI();

    }
    /********************** �Ђ����� *************************/
    //�Ђ����I��UI�\���֐�
    private void ultimateSelection()
    {
        //phase���o�g���A�N�V������
        phase = Phase.UltimateSelection;
        //�A�N�V�����Z���N�V����UI��\��
        ultimateSelectionUI.OpenSelectionUI();
    }
    //�Ђ�������
    private void ultimateMove()
    {
        //�^�[������   plyermove�ɂ킴(�I�𒆂�Index)����
        StartCoroutine(runTurns(playerUnit.Battler.UltimateMoves[ultimateSelectionUI.SelectedIndex]));

        //�s�����UI�����
        ultimateSelectionUI.CloseSelectionUI();
    }


    //���ǂ鏈��
    private void closeSelectionUI(BaseSelectionUI SelectionUI)
    {
        //phase���o�g���A�N�V������
        phase = Phase.ActionSelection;
        //�J���Ă���UI�����
        SelectionUI.CloseSelectionUI();
    }

    //���݂��̋Z����������u1�^�[���v�̓���
    private IEnumerator runTurns(Move playerMove)
    {
        //phase�ύX
        phase = Phase.RunTurns;

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
   
    //���݂��̋Z�ɂ��_�C�A���O
    private IEnumerator runMove(Move move, BattleUnit sourceUnit, BattleUnit targetUnit)
    {
        //�󂯎�����s���̃e�L�X�g����
        string resultText = move.Base.RunMoveResult(sourceUnit, targetUnit);
        //�s���̃e�L�X�g��\��
        yield return battleDialog.TypeDialog(resultText, auto: false);
        //��_���[�W�����ɂ��UI�X�V
        targetUnit.UpdateUI();
        //�Z�g�p�҂�UI�X�V(HP�񕜎�,�܂ق��g�p���Ɏg�p)
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

