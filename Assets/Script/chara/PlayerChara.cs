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
    public TextMeshProUGUI AttackTypeText1;
    public TextMeshProUGUI AttackTypeText2;
    public TextMeshProUGUI AttackTypeText3;

    [Header("TEXT")]

    public string attackText = "ATTACK1";
    public string attackText2 = "ATTACK2";
    public string attackText3 = "ATTACK3";
   
    public string notCost = "エネルギーが足りない";
    private int playerSelect = 0;
    private bool isCoolTime = false;
    private bool Judge = false;
    public float countDown = 2.0f;
    public TextMeshProUGUI timeText;
    public GameObject timeObject;

    private bool countDownFlag = false;
    public void OnAttackButton(int a)
    {
        playerSelect = a;
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

        if (countDownFlag)
        {
            countDown -= Time.deltaTime;
            timeText.text = countDown.ToString("F1");

            if (countDown <= 0)
            {
               countDownFlag = false;
               timeObject.SetActive(false);
            }
        }

    }

    private void StartCount()
    {
        countDownFlag = true;
        timeObject.SetActive(true);
    }
    protected void Start()
    {
        Slider.maxValue = maxHP;
        HP = maxHP;
        Slider.minValue = 0;
        Slider.value = HP;
        AttackTypeText1.text = attackText;
        AttackTypeText2.text = attackText2;
        AttackTypeText3.text = attackText3;

    }
    public override  void attack(characterBase target)
    {
        base.attack(target);
    }

    public virtual void Attack2()
    {
        _ = TextChara(attackText2);
    }

    public virtual void Attack3()
    {

        _ = TextChara(attackText3);

    }
    public virtual void Skill() { }

    public async UniTask Line()
    {

        await AttackCoolTime(2000);

        while (isCoolTime)
        {
            Debug.Log("クールタイム待ち");
            await UniTask.Yield();
        }

        Debug.Log("①CT終了");

        Judge = await critical.Instance.ReturnJudge();

        Debug.Log("②判定終了");

        SelectAttack(BattleManager.Instance.GiveEnemy());

        Debug.Log("③攻撃終了");
    }

    public void OnClickNum(int a)
    {
        playerSelect = a;
    }
    public virtual void SelectAttack(characterBase target)
    {
        Debug.Log("SelectAttack開始");
        switch (playerSelect)
        {
            case 0:
                Debug.Log("通常");
                attack(target);
                break;
            case 1:
                Debug.Log("攻撃２");
                Attack2();
                break;
            case 2:
                Debug.Log("攻撃3");
                Attack3();
                break;
            default:
                Debug.LogError("指定されてない値が入ってます");
                break;

        }
    }
    public async UniTask AttackCoolTime(int waitTime = 2000)
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
