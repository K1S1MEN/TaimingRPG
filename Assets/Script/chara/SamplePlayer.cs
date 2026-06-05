using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : PlayerChara
{
    
    void Start()
    {
        Name = "sample";
        HP = 200;
        maxHP = 200;
        id = 0;
        Attack = 35;
        Log = "サンプルキャラクター、何の変哲もないキャラでこれを元にいろんなキャラが作られる";
        attackCost = 1f;
        specialAttackCost = 3f;
        EXAttackCost = 5f;
    }

    public override void attack()
    {
        base.attack();
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
