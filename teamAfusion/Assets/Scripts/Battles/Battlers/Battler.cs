using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MoveBase;

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
    public List<Move> AttackMoves { get; set; }
    public List<Move>MagicMoves { get; set; }
    public List<Move> UltimateMoves { get; set; }

    //初期化処理
    public void Init()
    {
        MaxHp = _base.MaxHP;
        MaxMp = _base.MaxMP;
        HP = MaxHp;
        AT = _base.AT;
        MP = MaxMp;
        AttackMoves = new List<Move>();
        MagicMoves = new List<Move>();
        UltimateMoves = new List<Move>();
        foreach (var useableMove in Base.UseableMove)
        {    
            //switch文 データの本体.わざでーた.データのステータス
            switch(useableMove.MoveBase.MoveStatus)
            {
                case SkillType.Attack:
                    AttackMoves.Add(new Move(useableMove.MoveBase));
                    break;
                case SkillType.Magic:
                    MagicMoves.Add(new Move(useableMove.MoveBase));
                    break;
                case SkillType.Ultimate:
                    UltimateMoves.Add(new Move(useableMove.MoveBase));
                    break;
                default:break;
            }
        }
    }

    //「こうげき」行動のダメージ処理
    public int TakeDamage(int movePower, Battler attacker)
    {
        //アタッカーの攻撃力
        int damage = attacker.AT + movePower;
        //HPがマイナスにならないように
        HP = Mathf.Clamp(HP - damage, 0, MaxHp);

        return damage;
    }
    //「回復」行動の処理
    public void Heal(int healPoint)
    {
        //HPがマイナスにならないように
        HP = Mathf.Clamp(HP + healPoint, 0, MaxHp);
    }
    //「まほう」行動の処理
    public void Magic(int magicPoint)
    {
        //MPが0以下でHPからMPが引かれる
        if (MP > 0)
            MP = Mathf.Clamp(MP - magicPoint, 0, MaxMp);
        else
            HP = Mathf.Clamp(HP - magicPoint, 0, MaxHp);
    }

    //ランダムに一つわざを返す関数
    public Move GetRondomMove()
    {
        int r = Random.Range(0, AttackMoves.Count);
        return AttackMoves[r];
    }
}
