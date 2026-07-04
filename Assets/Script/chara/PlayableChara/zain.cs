using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zain : PlayerChara
{
    new void Start()
    {
        Slider.maxValue = maxHP;
        HP = maxHP;
        Slider.minValue = 0;
        Slider.value = HP;
    }
}
