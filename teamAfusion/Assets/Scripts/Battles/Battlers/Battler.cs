using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Move> Moves { get; set; }

    //����������
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

    //�_���[�W���󂯂鏈��
    public int TakeDamage(Move move, Battler attacker)
    {
        //�A�^�b�J�[�̍U����
        int damage = attacker.AT;// + move.Base.Power;
        //HP���}�C�i�X�ɂȂ�Ȃ��悤��
        HP = Mathf.Clamp(HP - damage, 0, MaxHp);

        return damage;
    }

    //�����_���Ɉ�킴��Ԃ��֐�
    public Move GetRondomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
