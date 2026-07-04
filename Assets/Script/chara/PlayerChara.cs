using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using Cysharp.Threading.Tasks;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "PlayerChara")]
public class PlayerChara : characterBase
{
    public UnityEngine.UI.Slider Slider;
    public TextMeshProUGUI charaText;

    [Header("TEXT")]

    public string attackText;
    public string specialAttackText;
    public string EXAttackText;
    public string notCost = "エネルギーが足りない";
    private int playerSelect = 0;
    private bool isCoolTime = false;
    private bool Judge = false;
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
        Slider.maxValue = maxHP;
        HP = maxHP;
        Slider.minValue = 0;
        Slider.value = HP;
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
            Debug.Log("ループ中");
            await AttackCoolTime(1000);

            while (isCoolTime)
            {
                Debug.Log("クールタイム待ち");
                await UniTask.Yield();
            }
            Judge = await critical.Instance.ReturnJudge();
            SelectAttack(bt.GiveEnemy());
            
    }

    public void OnClickNum(int a)
    {
        playerSelect = a;
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
        Debug.Log("クールタイム");
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
