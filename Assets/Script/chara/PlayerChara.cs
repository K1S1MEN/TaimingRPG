using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerChara : characterBase
{
    [SerializeField] Slider Slider;
    [SerializeField] TextMeshProUGUI costText;
    public TextMeshProUGUI charaText;
    protected float attackCost = 1f;
    protected float specialAttackCost = 1f;
    protected float EXAttackCost;
    protected float cost = 0f;
    public float costValue = 0.7f;
    protected string attackText;
    protected string specialAttackText;
    protected string EXAttackText;
    protected string notCost = "ÉGÉlÉãÉMÅ[Ç™ë´ÇËÇ»Ç¢";
    protected void FixedUpdate()
    {
        if (cost < 10f)
        {
            cost += costValue * Time.deltaTime;
            CostUpdate();
        }
        
    }

    protected void CostUpdate()
    {
        Slider.value = cost;
        costText.text = cost.ToString("F1"); ;
    }
    protected void Start()
    {
        Slider = GetComponent<Slider>();
    }
    public void CriticalCost()
    {
        if(cost <10f)
        {
            cost += 0.3f;
        }
    }
    protected override  int attack()
    {
        if (cost >= attackCost)
        {
            cost -= attackCost;
  
            TextChara(attackText);
            CostUpdate();
            return AttackPoint;
        }
        else
        {
            TextChara(notCost);
            return AttackPoint;
        }
        
    }

    public virtual void SpecialAttack() 
    {
        if (cost >= specialAttackCost)
        {
            cost -= specialAttackCost;
            TextChara(specialAttackText);
            CostUpdate();
        }
        else
        {
            TextChara(notCost);
        }
    }

    public virtual void EXSkill() 
    { 
        if (cost >= EXAttackCost)
        {
            cost -= EXAttackCost;
            TextChara(EXAttackText);
            CostUpdate();
        }
        else
        {
            TextChara(notCost);
        }
    }
    public virtual void Skill() { }
    protected async void TextChara(string a)
    {
        charaText.text = a;
        await Task.Delay(2000);
        charaText.text = "";
    }
}
