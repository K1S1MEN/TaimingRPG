using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChara : characterBase
{
    [SerializeField] Slider Slider;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI charaText;
    protected float attackCost = 1f;
    protected float specialAttackCost = 1f;
    protected float EXAttackCost;
    protected float cost = 0f;
    public float costValue = 0.7f;
    protected string attackText;
    protected string specialAttackText;
    protected string EXAttackText;
    protected void FixedUpdate()
    {
        if (cost < 10f)
        {
            cost += costValue * Time.deltaTime;
            Slider.value = cost;
            costText.text = cost.ToString("F1"); ;
        }
        
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
    public override  void attack()
    {
        if (cost >= attackCost)
        {
            cost -= attackCost;
            base.attack();
            Debug.Log("通常攻撃！！");
            TextChara(attackText);
            
        }
        else
        {
            Debug.Log("コストが足りません");
        }

    }

    public virtual void SpecialAttack() 
    {
        if (cost >= specialAttackCost)
        {
            cost -= specialAttackCost;
            Debug.Log("特殊攻撃！！");
            TextChara(specialAttackText);
        }
        else
        {
            Debug.Log("コストが足りません");
        }
    }

    public virtual void EXSkill() 
    { 
        if (cost >= EXAttackCost)
        {
            cost -= EXAttackCost;
            Debug.Log("必殺技！！");
            TextChara(EXAttackText);
        }
        else
        {
            Debug.Log("コストが足りません");
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
