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
    public State State1 { get => state1;}

    public enum State
    {
        Attack = 0,
        Magic = 1,
    }
    private State state1;
    //仮想関数宣言
    public virtual string RunMoveResult(BattleUnit sourcerUnit, BattleUnit targetUnit)
    {
        return "";
    }
}
