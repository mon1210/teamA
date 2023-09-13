using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//わざの基礎データ
[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    [SerializeField] new string name;
    //外部で取得できるように
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

    //仮想関数宣言
    public virtual string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        return "";
    }
}
