using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)‚ðŒp³‚µ‚½u‰ñ•œv‹Z‚ÌŠî‘bƒf[ƒ^
[CreateAssetMenu]
public class HealMoveBase : MoveBase
{
    [SerializeField] int healPoint;
    //ŠO•”‚ÅŽæ“¾‚Å‚«‚é‚æ‚¤‚É
    public int HealPoint { get => healPoint; }
}
