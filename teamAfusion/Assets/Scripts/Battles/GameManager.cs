using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] BattleSystem battleSystem;

    [SerializeField] Battler enemyBattler;
    // Start is called before the first frame update
    void Start()
    {
        enemyBattler.Init();
        battleSystem.BattleStart(player.Battler, enemyBattler);
    }

}
