using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)���p�������u���������v�Z�̊�b�f�[�^
[CreateAssetMenu]
public class AttackMoveBase : MoveBase
{
    [SerializeField] int power;
    //�O���Ŏ擾�ł���悤��
    public int Power { get => power; }

    //�֐��̃I�[�o�[���C�h
    public override string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int�^�Ŏ󂯎�����_���[�W���Z�b�g
        int damage = targetUnit.Battler.TakeDamage(power, sourcerUnit.Battler);
        //�_���[�W��^�����E�󂯂����O��Ԃ�
        return $"{sourcerUnit.Battler.Base.Name}��{Name}�I\n{targetUnit.Battler.Base.Name}��{damage}�̃_���[�W�I";
    }

}
