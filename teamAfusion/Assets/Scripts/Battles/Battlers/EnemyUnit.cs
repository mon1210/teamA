using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : BattleUnit
{
    [SerializeField] Text nameText;
    //セットアップのオーバーライド
    public override void Setup(Battler battler)
    {
        base.Setup(battler);
        //Enemyのステータス設定
        nameText.text = battler.Base.Name;
    }
}
