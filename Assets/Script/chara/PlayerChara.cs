using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using Cysharp.Threading.Tasks;

[CreateAssetMenu(menuName = "PlayerChara")]
public class PlayerChara : characterBase
{
    public Slider Slider;
    [SerializeField] TextMeshProUGUI costText;
    public TextMeshProUGUI charaText;

    [Header("TEXT")]

    public string attackText;
    public string specialAttackText;
    public string EXAttackText;
    public string notCost = "エネルギーが足りない";
    private int playerSelect = 0;
    private bool isCoolTime = false;
    BattleManager bt = BattleManager.Instance;
    public void OnAttackButton()
    {
        characterBase target = BattleManager.Instance.enemyMember[0];

        attack(target);
    }
    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.UpArrow) && playerSelect < 0 && isCoolTime)
        {
            playerSelect--;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && playerSelect < 3 && isCoolTime)
        {
            playerSelect++;
        }

    }
    protected void Start()
    {
        
    }
    public override  bool attack(characterBase target)
    {
        base.attack(target);
        return false;

    }

    public virtual void SpecialAttack()
    {
        _ = TextChara(specialAttackText);
    }

    public virtual void EXSkill()
    {

        _ = TextChara(EXAttackText);

    }
    public virtual void Skill() { }

    public async UniTask Line()
    {
        while (true)
        {
            await AttackCoolTime(1000);

            while (isCoolTime)
            {
                await UniTask.Yield();
            }
            SelectAttack(bt.GiveEnemy());
            if (BattleManager.finish)
            {
                break;
            }
            
        }
    }
    public virtual void SelectAttack(characterBase target)
    {
        switch (playerSelect)
        {
            case 0:
                Debug.Log("通常");
                attack(target);
                break;
            case 1:
                Debug.Log("SKILL");
                Skill();
                break;
            case 2:
                Debug.Log("EX");
                EXSkill();
                break;
            default:
                Debug.LogError("指定されてない値が入ってます");
                break;

        }
    }
    public async UniTask AttackCoolTime(int waitTime)
    {
        isCoolTime = true;
        await UniTask.Delay(waitTime);
        isCoolTime = false;
    }
    protected async UniTask TextChara(string a)
    {
        charaText.text = a;
        await UniTask.Delay(2000);
        charaText.text = "";
    }
}
