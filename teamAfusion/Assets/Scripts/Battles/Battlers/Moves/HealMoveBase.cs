using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)���p�������u�񕜁v�Z�̊�b�f�[�^
[CreateAssetMenu]
public class HealMoveBase : MoveBase
{
    [SerializeField] int healPoint;
    //�O���Ŏ擾�ł���悤��
    public int HealPoint { get => healPoint; }
}
