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
}
