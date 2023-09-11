using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)を継承した「こうげき」技の基礎データ
[CreateAssetMenu]
public class AttackMoveBase : MoveBase
{
    [SerializeField] int power;
    //外部で取得できるように
    public int Power { get => power; }

    //関数のオーバーライド
    public override string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int型で受け取ったダメージをセット
        int damage = targetUnit.Battler.TakeDamage(power, sourcerUnit.Battler);
        //ダメージを与えた・受けたログを返す
        return $"{sourcerUnit.Battler.Base.Name}の{Name}！\n{targetUnit.Battler.Base.Name}は{damage}のダメージ！";
    }

}
