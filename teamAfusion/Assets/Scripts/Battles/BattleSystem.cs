using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{ 
    //アクションセレクションUIの取得
    [SerializeField] ActionSelectionUI actionSelectionUI;
    //こうげき選択UIの取得
    [SerializeField] AttackSelectionUI attackSelectionUI;
    //まほう選択UIの取得
    [SerializeField] MagicSelectionUI magicSelectionUI;
    //ひっさつ選択UIの取得
    [SerializeField] UltimateSelectionUI ultimateSelectionUI;
    //ダイアログの取得
    [SerializeField] BattleDialog battleDialog;
    //player情報の取得
    [SerializeField] BattleUnit playerUnit;
    //enemy情報の取得
    [SerializeField] BattleUnit enemyUnit;
    //fadeに必要な素材の取得
    [SerializeField] Fade fade;

    //phase分けの変数宣言
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
    //Phase型の変数宣言
    Phase phase;

    //バトル開始時処理
    public void BattleStart(Battler player, Battler enemy)
    {
        //初期化処理
        phase = Phase.Start;
        //デバッグ
        Debug.Log("バトル開始");

        //子要素のSelectableTextを取得する関数の呼び出し
        actionSelectionUI.Init();
        attackSelectionUI.Init(player.Moves);
        magicSelectionUI.Init();
        ultimateSelectionUI.Init();

        actionSelectionUI.CloseSelectionUI();
        //バトル前のSetUp
        StartCoroutine(setupBattle(player, enemy));
    }

    //ダイアログのタイプが終わったらアクションセレクションへ
    private IEnumerator setupBattle(Battler player, Battler enemy)
    {
        //Unitに基本情報をセット
        playerUnit.Setup(player);
        enemyUnit.Setup(enemy);
        //表示しきるまで待機
        yield return battleDialog.TypeDialog($"{enemy.Base.Name}が現れた！\nどうする？");
        //アクションセレクションを用意する関数の呼び出し
        actionSelection();

    }

    // Update is called once per frame
    void Update()
    {
        //ActionSelectionUIを表示
        processBattlePhase();
    }

    //Phaseの処理分け
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

    //アクション選択関数
    private void handleActionSelection()
    {
        //選択したもののテキスト色変更
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
    //こうげき選択関数
    private void handleAttackSelection()
    {
        //選択したもののテキスト色変更
        attackSelectionUI.ChangeTextColor();

        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackMove();
        }
    }
    //まほう選択関数
    private void handleMagicSelection()
    {
        //選択したもののテキスト色変更
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
    //ひっさつ選択関数
    private void handleUltimateSelection()
    {
        //選択したもののテキスト色変更
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

    //アクション選択UI表示関数
    private void actionSelection()
    {
        //phaseをバトルアクションへ
        phase = Phase.ActionSelection;
        //アクションセレクションUIを表示
        actionSelectionUI.OpenSelectionUI();
    }

    /********************** こうげき *************************/
    //こうげき選択UI表示関数
    private void attackSelection()
    {
        //
        phase = Phase.AttackSelection;
        //
        attackSelectionUI.OpenSelectionUI();
    }
    //こうげき処理
    private void attackMove()
    {
        //ターン処理
        StartCoroutine(runTurns());

        //行動後にUIを閉じる
        attackSelectionUI.CloseSelectionUI(); 
    }

    /********************** まほう *************************/
    //まほう選択UI表示関数
    private void magicSelection()
    {
        //
        phase = Phase.MagicSelection;
        //
        magicSelectionUI.OpenSelectionUI();
    }
    //一つ目のまほう処理
    private void magicMove1()
    {
        Debug.Log("ほのお");

        //行動後にUIを閉じる
        magicSelectionUI.CloseSelectionUI();

        //ターン処理
        StartCoroutine(runTurns());

    }
    //二つ目のまほう処理
    private void magicMove2()
    {
        Debug.Log("こおり");
        
        //行動後にUIを閉じる
        magicSelectionUI.CloseSelectionUI();

        //ターン処理
        StartCoroutine(runTurns());

    }
    //三つ目のまほう処理
    private void magicMove3()
    {
        Debug.Log("かみなり");

        //行動後にUIを閉じる
        magicSelectionUI.CloseSelectionUI();

        //ターン処理
        StartCoroutine(runTurns());

    }
    //もどる
    private void magicBack()
    {
        //
        phase = Phase.ActionSelection;
        //
        magicSelectionUI.CloseSelectionUI();
    }


    /********************** ひっさつ *************************/
    //ひっさつ選択UI表示関数
    private void ultimateSelection()
    {
        //
        phase = Phase.UltimateSelection;
        //
        ultimateSelectionUI.OpenSelectionUI();
    }
    //一つ目のひっさつ処理
    private void ultimateMove1()
    {
        Debug.Log("こうていぺんぎん");

        //行動後にUIを閉じる
        ultimateSelectionUI.CloseSelectionUI();

        //ターン処理
        StartCoroutine(runTurns());
    }
    //二つ目のひっさつ処理
    private void ultimateMove2()
    {
        Debug.Log("ごっどはんど");

        //行動後にUIを閉じる
        ultimateSelectionUI.CloseSelectionUI();

        //ターン処理
        StartCoroutine(runTurns());
    }
    //もどる
    private void ultimateBack()
    {
        //
        phase = Phase.ActionSelection;
        //
        ultimateSelectionUI.CloseSelectionUI();
    }


    //お互いの技が発生する「1ターン」の動き
    private IEnumerator runTurns()
    {
        //phase変更
        phase = Phase.RunTurns;

        //plyermoveにわざ(選択中のIndex)を代入
        Move playerMove = playerUnit.Battler.Moves[attackSelectionUI.SelectedIndex];
        //自分の攻撃
        yield return runMove(playerMove,playerUnit, enemyUnit);
        //勝利処理
        if(phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{enemyUnit.Battler.Base.Name}をたおした！");
            yield break;
        }

        //enemymoveにランダムに一つわざを代入
        Move enemyMove = enemyUnit.Battler.GetRondomMove();
        //敵の攻撃
        yield return runMove(enemyMove,enemyUnit, playerUnit);
        //敗北処理
        if (phase == Phase.BattleOver)
        {
            yield return battleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}は目の前がまっくらになった！", auto: false);
            phase = Phase.GameOver;
            if (phase == Phase.GameOver)
            {
                OnNextScene();
            }
            yield break;
        }

        //ターン終了時ダイアログ
        yield return battleDialog.TypeDialog("どうする？");
        //アクションセレクションへ戻る
        actionSelection();
    }

    //お互いの技によるダイアログ
    private IEnumerator runMove(Move move, BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int型で受け取ったダメージをセット
        int damage = targetUnit.Battler.TakeDamage(move, sourcerUnit.Battler);
        //ダメージを与えた・受けたログを表示
        yield return battleDialog.TypeDialog($"{sourcerUnit.Battler.Base.Name}の{move.Base.Name}！\n{targetUnit.Battler.Base.Name}は{damage}のダメージ！", auto: false);
        //ダメージ処理でUI更新
        targetUnit.UpdateUI();
        //被ダメージ者がHP0以下でPhase切り替え
        if (targetUnit.Battler.HP <= 0) 
        {
            phase = Phase.BattleOver;
        }
    }
    //2秒かけてフェードアウトしてシーン切り替え
    private void OnNextScene()
    {
        fade.FadeIn(2.0f, () => SceneManager.LoadScene("TitleScene"));
    }
}

