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

    public enum SkillType
    {
        Default = -1,
        Attack,
        Magic,
    }
    [SerializeField]private SkillType moveStatus;
    public SkillType MoveStatus { get => moveStatus; }

    // enum{ Default = -1

    //���z�֐��錾
    public virtual string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        return "";
    }
}
