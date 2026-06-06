using System.Collections;
using System.Collections.Generic;
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
    public override void attack()
    {
        base.attack();
    }
}
