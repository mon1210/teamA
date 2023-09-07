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

    //����������
    public void Init()
    {
        MaxHp = _base.MaxHP;
        MaxMp = _base.MaxMP;
        HP = MaxHp;
        AT = _base.AT;
        MP = MaxMp;
    }

    //�_���[�W���󂯂鏈��
    public int TakeDamage(Battler attacker)
    {
        //�A�^�b�J�[�̍U����
        int damage = attacker.AT;
        //HP���}�C�i�X�ɂȂ�Ȃ��悤��
        HP = Mathf.Clamp(HP - damage, 0, MaxHp);

        return damage;
    }
}
