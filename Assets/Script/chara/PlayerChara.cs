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
    public Animator animator;

    [Header("TEXT")]

    public string attackText = "ATTACK1";
    public string attackText2 = "ATTACK2";
    public string attackText3 = "ATTACK3";
   
    private int playerSelect = 0;
    private bool isCoolTime = false;
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

        if (Input.GetKeyUp(KeyCode.UpArrow) && playerSelect > 0 && isCoolTime)
        {
            playerSelect--;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && playerSelect < 2 && isCoolTime)
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

    public override void Damage(int ATP)
    {
        Slider.value = HP;
        base.Damage(ATP);
    }

    private void StartCount()
    {
        Slider.maxValue = maxHP;
        HP = maxHP;
        Slider.minValue = 0;
        Slider.value = HP;
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
        animator = GetComponent<Animator>();

    }
    public override  void attack(characterBase target,bool Judge)
    {
        animator.SetTrigger("attack1");
        base.attack(target, Judge);
        _ = TextChara(attackText);
    }

    public virtual void Attack2(characterBase target, bool Judge)
    {
        animator.SetTrigger("attack2");
        _ = TextChara(attackText2);
    }

    public virtual void Attack3(characterBase target, bool Judge)
    {
        animator.SetTrigger("attack3");

        _ = TextChara(attackText3);

    }

    public async UniTask Line()
    {

        await AttackCoolTime(2000);

        while (isCoolTime)
        {
            await UniTask.Yield();
        }

        bool Judge = await critical.Instance.ReturnJudge();


        SelectAttack(BattleManager.Instance.GiveEnemy(),Judge);
    }

    public virtual void SelectAttack(characterBase target,bool Judge)
    {
        switch (playerSelect)
        {
            case 0:
                Debug.Log("çUåÇÇP");
                attack(target, Judge);
                break;
            case 1:
                Debug.Log("çUåÇÇQ");
                Attack2(target, Judge);
                break;
            case 2:
                Debug.Log("çUåÇ3");
                Attack3(target, Judge);
                break;
            default:
                Debug.LogError("éwíËÇ≥ÇÍÇƒÇ»Ç¢ílÇ™ì¸Ç¡ÇƒÇ‹Ç∑Åi"+playerSelect+")");
                break;

        }
    }
    public async UniTask AttackCoolTime(int waitTime = 2000)
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
