using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
using UnityEngine;

public class AegisHenchman : EnemyChara
{
    [SerializeField] TextMeshProUGUI nameText;
    new void Start()
    {
        Name = "AegisHenchman";
        nameText.text = Name;
        HP = 400;
        maxHP = 400;
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
