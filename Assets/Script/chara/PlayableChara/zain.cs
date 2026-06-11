using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class zain : PlayerChara
{
    int energy = 0;
    public TextMeshProUGUI Energy;
    
    void Start()
    {
        Name = "ザイン";
        HP = 250;
        maxHP = 200;
        id = 1;
        Attack = 50;
        Log = "謎のロボット。";
        attackCost = 1f;
        specialAttackCost = 2f;
        EXAttackCost = 8f;
        attackText = "えいっ";
        specialAttackText = "エネルギーチャージ";
        EXAttackText = "可能性を解放します";
        Energy.text = energy.ToString();
    }

    public override void attack(characterBase target)
    {
        if (energy >= 1)
        {
            AttackPoint = Attack * energy;
        }
        
        base.attack(target);
    }

    public override void SpecialAttack()
    {
        if (energy <= 2)
        {
            energy++;
            Energy.text = energy.ToString();
            base.SpecialAttack();
        }
        else
        {
            charaText.text = "エネルギーMAXだ";
        }
    }

    public override void EXSkill()
    {
        base.EXSkill();

    }

}
