using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SEManager;

//MoveBase(Name)を継承した「ひっさつ」技の基礎データ
[CreateAssetMenu]
public class UltimateMoveBase : MoveBase
{
    //
    [SerializeField] int power;
    //
    [SerializeField] int magicPoint;
    //外部で取得できるように
    public int MagicPoint { get => magicPoint; }
    public int Power { get => power; }

    //関数のオーバーライド
    public override string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int型でmagicPointを受け取る
        sourcerUnit.Battler.Magic(magicPoint);
        //int型で受け取ったダメージをセット
        int damage = targetUnit.Battler.TakeDamage(power, sourcerUnit.Battler);
        //必殺SE再生
        SEManager.Instance.PlaySE(SESoundData.SE.Ultimate);
        //ダメージSE再生
        SEManager.Instance.PlaySE(SESoundData.SE.Damage);
        //ダメージを与えた・受けたログを返す
        return $"{sourcerUnit.Battler.Base.Name}はちからをふりしぼった！\nひっさつわざ「{Name}」！\n{targetUnit.Battler.Base.Name}に{damage}のダメージ！";
    }
}
