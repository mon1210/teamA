using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BattlerBase : ScriptableObject
{
    //Battlerの基礎データ
    [SerializeField] new private string name;
    [SerializeField] int maxHp;
    [SerializeField] int maxMp;
    [SerializeField] int attack;
    [SerializeField] Sprite sprite;
    [SerializeField] List<UseableMove> useableMove;

    //別ファイルから取得できるように
    public string Name { get => name;}
    public int MaxHP { get => maxHp;}
    public int AT { get => attack;}
    public Sprite Sprite { get => sprite;}
    public int MaxMP { get => maxMp;}
    public List<UseableMove> UseableMove { get => useableMove; }
}
