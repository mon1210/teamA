using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MoveBase(Name)‚ðŒp³‚µ‚½u‚±‚¤‚°‚«v‹Z‚ÌŠî‘bƒf[ƒ^
[CreateAssetMenu]
public class AttackMoveBase : MoveBase
{
    [SerializeField] int power;
    //ŠO•”‚ÅŽæ“¾‚Å‚«‚é‚æ‚¤‚É
    public int Power { get => power; }

}
