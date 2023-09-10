using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)を継承した「回復」技の基礎データ
[CreateAssetMenu]
public class HealMoveBase : MoveBase
{
    [SerializeField] int healPoint;
    //外部で取得できるように
    public int HealPoint { get => healPoint; }
}
