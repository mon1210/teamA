using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    //設定した技を取得
    public MoveBase Base {  get; set; }
    public Move(MoveBase moveBase) 
    {
        Base = moveBase; 
    }

}
