using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    //UIEBattler‚ÌŠÇ—
    public Battler Battler { get; set; }

    public virtual void Setup(Battler battler)
    {
        Battler = battler;

    }
}
