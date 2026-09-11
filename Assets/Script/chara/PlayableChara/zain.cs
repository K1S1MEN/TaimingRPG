using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zain : PlayerChara
{

   public override void Attack2(characterBase target, bool Judge)
    {
        base.Attack2(target, Judge);
        if (Judge)
        {
            for (int a = 0; a < 5; a++)
            {
                AttackPoint = Attack / 5;
                target.Damage(AttackPoint);
            }
        }
        
            
    }
    public override void Attack3(characterBase target, bool Judge)
    {
        if (Judge)
        {
            base.Attack3(target, Judge);
            HP += 50;
            Slider.value = HP;
        }
        
    }
}
