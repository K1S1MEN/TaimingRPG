using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yokoyama : EnemyChara
{
    new void Start()
    {
        Name = "AegisBlock";
        HP = 800;
        maxHP = 800;
        id = 1;
        Attack = 5;
        Log = "HP‚ª‚ ‚è‚¦‚È‚¢‚®‚ç‚¢‘½‚¢";
        coolTime = 20000;
        base.Start();
        

    }
    public override void attack(characterBase target, bool Judge)
    {
        base.attack(target, Judge);
    }
}
