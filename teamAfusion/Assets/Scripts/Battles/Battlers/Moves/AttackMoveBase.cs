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

}
