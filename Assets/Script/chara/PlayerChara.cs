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

    [Header("TEXT")]

    public string attackText;
    public string specialAttackText;
    public string EXAttackText;
    public string notCost = "エネルギーが足りない";
    private int playerSelect = 0;
    private bool isCoolTime = false;
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
        TextChara(specialAttackText);
    }

    public virtual void EXSkill()
    {

        TextChara(EXAttackText);

    }
    public virtual void Skill() { }
    public async Task<bool> AttackCoolTime(int waitTime,characterBase target)
    {
        isCoolTime = true;    
    
    await Task.Delay(waitTime);

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

        isCoolTime = false;
        return true;
    }
    protected async void TextChara(string a)
    {
        charaText.text = a;
        await Task.Delay(2000);
        charaText.text = "";
    }
}
