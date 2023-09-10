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

    //わざリスト
    public List<Move> Moves { get; set; }

    //初期化処理
    public void Init()
    {
        MaxHp = _base.MaxHP;
        MaxMp = _base.MaxMP;
        HP = MaxHp;
        AT = _base.AT;
        MP = MaxMp;
        Moves = new List<Move>();
        foreach (var useableMove in Base.UseableMove)
        {
            Moves.Add(new Move(useableMove.MoveBase));
        }

    }

    //ダメージを受ける処理
    public int TakeDamage(Move move, Battler attacker)
    {
        //アタッカーの攻撃力
        int damage = attacker.AT + move.Base.Power;
        //HPがマイナスにならないように
        HP = Mathf.Clamp(HP - damage, 0, MaxHp);

        return damage;
    }

    //ランダムに一つわざを返す関数
    public Move GetRondomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
