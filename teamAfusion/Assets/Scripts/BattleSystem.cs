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
        //子要素のSelectableTextを取得する関数の呼び出し
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
        //phaseをバトルアクションへ
        phase = Phase.ActionSelection;
        //アクションセレクションUIを表示
        actionSelectionUI.OpenActionSelectionUI();
    }

    private void handleActionSelection()
    {
        //選択したもののテキスト色変更
        actionSelectionUI.ChangeTextColor();

        //
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (actionSelectionUI.SelectedIndex == 0)
            {
                Debug.Log("こうげき");
            }
            else if (actionSelectionUI.SelectedIndex == 1)
            {
                Debug.Log("まほう");
            }
            else
            {
                Debug.Log("ひっさつ");
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

