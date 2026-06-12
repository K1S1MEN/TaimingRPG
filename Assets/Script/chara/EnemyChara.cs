using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChara : characterBase
{
    public Slider HPSlider;
    public int EXP;
    public int coolTime;
    public TextMeshProUGUI charaText;

    protected void Start()
    {
        HPSlider.maxValue = maxHP;
        HP = maxHP; 
        HPSlider.minValue = 0;
        HPSlider.value = HP;
    }
    protected async Task TextChara(string a)
    {
        charaText.text = a;
        await Task.Delay(2000);
        charaText.text = "";
    }
}
