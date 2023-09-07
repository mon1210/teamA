using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : BattleUnit
{
    [SerializeField] Text nameText;
    //�Z�b�g�A�b�v�̃I�[�o�[���C�h
    public override void Setup(Battler battler)
    {
        base.Setup(battler);
        //Enemy�̃X�e�[�^�X�ݒ�
        nameText.text = battler.Base.Name;
    }
}
