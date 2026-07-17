using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public static bool finish = false;


    public List<EnemyChara> enemyMember = new List<EnemyChara>();

    public List<PlayerChara> playerMember = new List<PlayerChara>();

    public bool ActivFlag;

    public int Count;

    public TextMeshProUGUI nowTurnText;

    private int TurnCount;
    

    private int SelectCharacterNum;

    public void CreateParty()
    {
        
    }
    public void CreateEnemy()
    {
        
    }

    private void StartEnemyAttack()
    {
        for (int i = 0; i < enemyMember.Count; i++)
        {
            _ = EnemyAttack(i);
        }
    }

    private async UniTask EnemyAttack(int i)
    {
        while (true)
        {
            Debug.Log("エネミーの攻撃");
            await enemyMember[i].Loop();
            
            if (playerMember.Count < 0)
            {
                Debug.Log("終わり");
                Finish();
                break;
            }
            Debug.Log("位置ループ終わり");
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _ = Maneger();
        StartEnemyAttack();
    }
    
    private void FixedUpdate()
    {
        
    }
    public void Finish()
    {

        Debug.LogError("この先の処理はまだ出来てない"); 
    }
    public async Task Maneger()
    {
       ActivFlag = true;

        while (true)
        {
            if(enemyMember.Count <= 0)
            {
                Finish();
                return;
            }
            else
            {
                nowTurnText.text = "COOL TIME";
                await playerMember[Count].Line();
            }
            if (Count < playerMember.Count)
            {
                Count = 0;
            }
            else
            {
                Count++;
            }
            TurnCount++;
        }
    }
    public EnemyChara GiveEnemy()
    {
        return enemyMember[Random.Range(0,enemyMember.Count)];
    }
    public PlayerChara GivePlayer()
    {
        return playerMember[Random.Range(0, playerMember.Count)];
    }

    private void CheckEnemy()
    {
        if (enemyMember.Count <= 0)
        {
            Finish();
        }
    }
}
