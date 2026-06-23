using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(menuName = "PlayerChara")]
public class PlayerChara : characterBase
{
    public Slider Slider;
    [SerializeField] TextMeshProUGUI costText;
    public TextMeshProUGUI charaText;
    protected float attackCost = 1f;
    protected float specialAttackCost = 1f;
    protected float EXAttackCost;
    public float cost = 0f;
    public float costValue = 0.7f;
    [Header("TEXT")]

    public string attackText;
    public string specialAttackText;
    public string EXAttackText;
    public string notCost = "エネルギーが足りない";
    protected void FixedUpdate()
    {
        if (cost < 10f)
        {
            cost += costValue * Time.deltaTime;
            CostUpdate();
        }
        
    }
    public void OnAttackButton()
    {
        characterBase target = BattleManager.Instance.enemyMember[0];

        attack(target);
    }

    protected void CostUpdate()
    {
        Slider.value = cost;
        costText.text = cost.ToString("F1"); ;
    }
    protected void Start()
    {

    }
    public void CriticalCost()
    {
        if(cost <10f)
        {
            BattleManager.Instance.playerMember[0].cost += 0.3f;
            BattleManager.Instance.playerMember[1].cost += 0.3f;
            BattleManager.Instance.playerMember[2].cost += 0.3f;
        }
    }
    public override  bool attack(characterBase target)
    {
        base.attack(target);
        if (cost >= attackCost)
        {
            cost -= attackCost;
            switch (Judgment())
            {
                case 0:
                    break;
                case 1:
                    target.Damage(AttackPoint);
                    TextChara(attackText);
                    break;
                case 2:
                    target.Damage(AttackPoint*2);
                    CriticalCost();
                    TextChara(attackText);
                    return true;
            }
            
            
            CostUpdate();
            
        }
        else
        {
            TextChara(notCost);

        }
        return false;

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
            characterBase t = BattleManager.Instance.enemyMember[0];
            cost -= EXAttackCost;
            TextChara(EXAttackText);
            CostUpdate();
            t.Damage(AttackPoint);
        }
        else
        {
            TextChara(notCost);
        }
    }
    public virtual void Skill() { }
    public async Task<bool> AttackCoolTime(int waitTime,int type)
    {
        await Task.Delay(waitTime);

        switch (type)
        {
            case 0:
                Debug.Log("通常");
                break;
                case 1:
                Debug.Log("SKILL");
                break;
                case 2:
                Debug.Log("EX");
                break;
                default:
                Debug.LogError("指定されてない値が入ってます");
                break;

        }
        return true;
    }
    protected async void TextChara(string a)
    {
        charaText.text = a;
        await Task.Delay(2000);
        charaText.text = "";
    }
}
