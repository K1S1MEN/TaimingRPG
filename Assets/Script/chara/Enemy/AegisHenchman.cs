using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
using UnityEngine;

public class AegisHenchman : EnemyChara
{
    [SerializeField] TextMeshProUGUI nameText;
    AudioSource audioSource;
    public AudioClip sound1;

    new void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Name = "AegisHenchman";
        HP = 400;
        maxHP = 400;
        id = 1;
        Attack = 15;
        Log = "‚¿‚Ñ";
        coolTime = 1000;
        base.Start();



    }
    public override void attack(characterBase target, bool Judge)
    {
        audioSource.PlayOneShot(sound1);
        base.attack(target,Judge);
    }
}
