using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UseableMove
{
    //�g����킴�̃��X�g����
    [SerializeField] MoveBase moveBase;

    public MoveBase MoveBase { get => moveBase; }
}
