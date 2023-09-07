using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battler
{
    [SerializeField] BattlerBase _base;

    public BattlerBase Base { get => _base; }

    //ステータス
    public int MaxHp { get ; set; }
    public int MaxMp { get ; set; }
    public int HP { get ; set; }
    public int MP { get ; set; }
    public int AT { get ; set; }

    //初期化処理
    public void Init()
    {
        MaxHp = _base.MaxHP;
        MaxMp = _base.MaxMP;
        HP = MaxHp;
        AT = _base.AT;
        MP = MaxMp;
    }

    //ダメージを受ける処理
    public int TakeDamage(Battler attacker)
    {
        //アタッカーの攻撃力
        int damage = attacker.AT;
        //HPがマイナスにならないように
        HP = Mathf.Clamp(HP - damage, 0, MaxHp);

        return damage;
    }
}
