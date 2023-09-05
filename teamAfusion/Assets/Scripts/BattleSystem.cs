using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
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
        phase= Phase.Start;

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
                phase = Phase.ActionSelection;
                break;
            case Phase.ActionSelection:
                HandleActionSelection();
                break;
            case Phase.AttackSelection:
                HandleAttackSelection();
                break;
            case Phase.MagicSelection:
                HandleMagicSelection();
                break;
            case Phase.BattleOver:
                break;
            default:
                break;
        }
    }
    private void HandleActionSelection()
    {

    }
    private void HandleAttackSelection()
    {

    }
    private void HandleMagicSelection()
    {


    }
}

