using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)を継承した「回復」技の基礎データ
[CreateAssetMenu]
public class HealMoveBase : MoveBase
{
    [SerializeField] int healPoint;
    //外部で取得できるように
    public int HealPoint { get => healPoint; }

    //関数のオーバーライド
    public override string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int型でhealPointを受け取る
        sourcerUnit.Battler.Heal(healPoint);
        //回復したダイアログを返す
        return $"{sourcerUnit.Battler.Base.Name}の{Name}!\n{sourcerUnit.Battler.Base.Name}はHPを{healPoint}回復した！";
    }
}
