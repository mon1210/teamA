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
}
