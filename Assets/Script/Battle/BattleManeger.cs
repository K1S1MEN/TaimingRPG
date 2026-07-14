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
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
         CreateEnemy();
        CreateParty();
        _ = Maneger();
    }
    
    private void FixedUpdate()
    {
        
    }
    public void Finish()
    {

        Debug.LogError("‚±‚Ìæ‚Ìˆ—‚Í‚Ü‚¾o—ˆ‚Ä‚È‚¢"); 
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
