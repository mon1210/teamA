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
        //子要素のSelectableTextを取得する関数の呼び出し
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
        //ActionSelectionUIを表示
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
    //一つ目のこうげき処理
    private void attackMove1()
    {
        Debug.Log("ぶんまわす");
        runTurns();
        attackSelectionUI.CloseSelectionUI();

    }
    //二つ目のこうげき処理
    private void attackMove2()
    {
        Debug.Log("よくねらう");
        runTurns();
        attackSelectionUI.CloseSelectionUI();
    }
    //もどる
    private void attackBack()
    {
        //
        phase = Phase.ActionSelection;
        //
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
        runTurns();
        magicSelectionUI.CloseSelectionUI();
    }
    //二つ目のまほう処理
    private void magicMove2()
    {
        Debug.Log("こおり");
        runTurns();
        magicSelectionUI.CloseSelectionUI();
    }
    //三つ目のまほう処理
    private void magicMove3()
    {
        Debug.Log("かみなり");
        runTurns();
        magicSelectionUI.CloseSelectionUI();
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
        runTurns();
        ultimateSelectionUI.CloseSelectionUI();
    }
    //二つ目のひっさつ処理
    private void ultimateMove2()
    {
        Debug.Log("ごっどはんど");
        runTurns();
        ultimateSelectionUI.CloseSelectionUI();
    }
    //もどる
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
        Debug.Log("両者の攻撃処理");
        actionSelection();
    }

}

