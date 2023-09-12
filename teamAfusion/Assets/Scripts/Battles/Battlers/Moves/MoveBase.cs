using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�킴�̊�b�f�[�^
[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    [SerializeField] new string name;
    //�O���Ŏ擾�ł���悤��
    public string Name { get => name; }
    public State State1 { get => state1;}

    public enum State
    {
        Attack = 0,
        Magic = 1,
    }
    private State state1;
    //���z�֐��錾
    public virtual string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        return "";
    }
}
