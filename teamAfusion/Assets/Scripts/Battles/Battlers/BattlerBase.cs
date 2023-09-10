using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BattlerBase : ScriptableObject
{
    //Battler�̊�b�f�[�^
    [SerializeField] new private string name;
    [SerializeField] int maxHp;
    [SerializeField] int maxMp;
    [SerializeField] int attack;
    [SerializeField] Sprite sprite;
    [SerializeField] List<UseableMove> useableMove;

    //�ʃt�@�C������擾�ł���悤��
    public string Name { get => name;}
    public int MaxHP { get => maxHp;}
    public int AT { get => attack;}
    public Sprite Sprite { get => sprite;}
    public int MaxMP { get => maxMp;}
    public List<UseableMove> UseableMove { get => useableMove; }
}
