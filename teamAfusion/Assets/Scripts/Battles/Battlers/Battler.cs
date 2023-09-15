using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MoveBase;

[System.Serializable]
public class Battler
{
    [SerializeField] BattlerBase _base;

    public BattlerBase Base { get => _base; }

    //�X�e�[�^�X
    public int MaxHp { get ; set; }
    public int MaxMp { get ; set; }
    public int HP { get ; set; }
    public int MP { get ; set; }
    public int AT { get ; set; }

    //�킴���X�g
    public List<Move> AttackMoves { get; set; }
    public List<Move>MagicMoves { get; set; }
    public List<Move> UltimateMoves { get; set; }

    //����������
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
            //switch�� �f�[�^�̖{��.�킴�Ł[��.�f�[�^�̃X�e�[�^�X
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

    //�u���������v�s���̃_���[�W����
    public int TakeDamage(int movePower, Battler attacker)
    {
        //�A�^�b�J�[�̍U����
        int damage = attacker.AT + movePower;
        //HP���}�C�i�X�ɂȂ�Ȃ��悤��
        HP = Mathf.Clamp(HP - damage, 0, MaxHp);

        return damage;
    }
    //�u�񕜁v�s���̏���
    public void Heal(int healPoint)
    {
        //HP���}�C�i�X�ɂȂ�Ȃ��悤��
        HP = Mathf.Clamp(HP + healPoint, 0, MaxHp);
    }
    //�u�܂ق��v�s���̏���
    public void Magic(int magicPoint)
    {
        //MP��0�ȉ���HP����MP���������
        if (MP > 0)
            MP = Mathf.Clamp(MP - magicPoint, 0, MaxMp);
        else
            HP = Mathf.Clamp(HP - magicPoint, 0, MaxHp);
    }

    //�����_���Ɉ�킴��Ԃ��֐�
    public Move GetRondomMove()
    {
        int r = Random.Range(0, AttackMoves.Count);
        return AttackMoves[r];
    }
}
