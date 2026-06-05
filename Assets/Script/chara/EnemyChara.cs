using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChara : characterBase
{
    [SerializeField] Slider HPSlider;
    public int EXP;

    private void FixedUpdate()
    {
        
    }
    private void Start()
    {
        HPSlider = GetComponent<Slider>();
        HPSlider.maxValue = maxHP;
        HPSlider.minValue = 0;
        HPSlider.value = HP;
    }
}
