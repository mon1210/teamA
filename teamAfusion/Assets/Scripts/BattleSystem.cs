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
    //アクション選択関数
    private void actionSelection()
    {
        //phaseをバトルアクションへ
        phase = Phase.ActionSelection;
        //アクションセレクションUIを表示
        actionSelectionUI.OpenSelectionUI();
    }

    //こうげき選択関数
    private void attackSelection()
    {
        //
        phase = Phase.AttackSelection;
        //
        attackSelectionUI.OpenSelectionUI();
    }

    //まほう選択関数
    private void magicSelection()
    {
        //
        phase = Phase.MagicSelection;
        //
        magicSelectionUI.OpenSelectionUI();
    }

    //ひっさつ選択関数
    private void ultimateSelection()
    {
        //
        phase = Phase.UltimateSelection;
        //
        ultimateSelectionUI.OpenSelectionUI();
    }

    //アクション選択処理関数
    private void handleActionSelection()
    {
        //選択したもののテキスト色変更
        actionSelectionUI.ChangeTextColor();

        //
        if(Input.GetKeyDown(KeyCode.Space))
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
    private void handleAttackSelection()
    {

    }
    private void handleMagicSelection()
    {


    }
}

