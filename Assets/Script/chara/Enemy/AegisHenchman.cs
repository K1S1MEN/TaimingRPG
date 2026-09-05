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
        id = 1;
        Log = "‚¿‚Ñ";
        coolTime = 10000;
        base.Start();



    }
    public override void attack(characterBase target, bool Judge)
    {
        audioSource.PlayOneShot(sound1);
        base.attack(target,Judge);
    }
}
