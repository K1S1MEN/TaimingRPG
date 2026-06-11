using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer2 : PlayerChara
{
    void Start()
    {
        Name = "sample";
        HP = 200;
        maxHP = 200;
        id = 0;
        Attack = 35;
        Log = "サンプルキャラクター２,ネタがない";
        attackCost = 1f;
        specialAttackCost = 3f;
        EXAttackCost = 5f;
        attackText = "オラぁ！！";
        specialAttackText = "俺バカだから分かんねぇけどよぉ";
        EXAttackText = "ザ・ハンドで消す！！";
    }

    public override void  attack(characterBase target)
    {
        base.attack(target);
    }

    public override void SpecialAttack()
    {
        base.SpecialAttack();
    }

    public override void EXSkill()
    {
        base.EXSkill();

    }



}
