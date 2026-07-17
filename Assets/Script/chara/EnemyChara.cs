using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.UIElements;
public class EnemyChara : characterBase
{
    public UnityEngine.UI.Slider HPSlider;
    public int EXP;
    public int coolTime = 10000;
    public TextMeshProUGUI charaText;
    protected void Start()
    {
        //HPSlider = GetComponentInChildren<Slider>();
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

    public override void Damage(int d)
    {
        base.Damage(d);
        HPSlider.value = HP;
        if (HP <= 0)
        {
            BattleManager.Instance.enemyMember.Remove(this);
            Destroy(this.gameObject);
        }

    }

    public void Update()
    {
        
    }

    public async UniTask Loop()
    {
            await UniTask.Delay(1000);
        attack(BattleManager.Instance.GivePlayer(), false);
    }
}
