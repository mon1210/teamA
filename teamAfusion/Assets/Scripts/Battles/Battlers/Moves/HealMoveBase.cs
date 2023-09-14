using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)���p�������u�񕜁v�Z�̊�b�f�[�^
[CreateAssetMenu]
public class HealMoveBase : MoveBase
{
    //
    [SerializeField] int healPoint;
    //
    [SerializeField] int magicPoint;

    //�O���Ŏ擾�ł���悤��
    public int HealPoint { get => healPoint; }
    public int MagicPoint { get => magicPoint; }

    //�֐��̃I�[�o�[���C�h
    public override string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        //int�^��magicPoint���󂯎��
        sourcerUnit.Battler.Magic(magicPoint);
        //int�^��healPoint���󂯎��
        sourcerUnit.Battler.Heal(healPoint);
        //�񕜂����_�C�A���O��Ԃ�
        return $"{sourcerUnit.Battler.Base.Name}��{Name}!\n{sourcerUnit.Battler.Base.Name}��HP��{healPoint}�񕜂����I";
    }
}
