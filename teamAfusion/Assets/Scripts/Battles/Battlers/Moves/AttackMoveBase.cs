using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SEManager;

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
        //�A�^�b�NSE�Đ�
        SEManager.Instance.PlaySE(SESoundData.SE.Attack);
        //�_���[�WSE�Đ�
        SEManager.Instance.PlaySE(SESoundData.SE.Damage);
        //�_���[�W��^�����E�󂯂����O��Ԃ�
        return $"{sourcerUnit.Battler.Base.Name}�́u{Name}�v�I\n{targetUnit.Battler.Base.Name}��{damage}�̃_���[�W�I";
    }

}
