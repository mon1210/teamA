using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    //�ݒ肵���Z���擾
    public MoveBase Base {  get; set; }
    public Move(MoveBase moveBase) 
    {
        Base = moveBase; 
    }

}
