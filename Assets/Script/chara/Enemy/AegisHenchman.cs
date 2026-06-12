using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class AegisHenchman : EnemyChara
{
    new void Start()
    {
        Name = "AegisHenchman";
        HP = 50;
        maxHP = 50;
        id = 200;
        Attack = 15;
        Log = "‚¿‚Ñ";
        base.Start();
        
    }
    public override void attack(characterBase target)
    {
        base.attack(target);
    }
}
