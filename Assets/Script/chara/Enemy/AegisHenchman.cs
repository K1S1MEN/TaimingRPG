using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class AegisHenchman : EnemyChara
{
    void Start()
    {
        Name = "AegisHenchman";
        HP = 50;
        maxHP = 50;
        id = 200;
        Attack = 15;
        Log = "‚¿‚Ñ";
    }
    protected override int attack()
    {
        base.attack();
        return AttackPoint;
    }
}
