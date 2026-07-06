using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public static bool finish = false;

    public List<EnemyChara> enemyMember = new List<EnemyChara>();

    public List<PlayerChara> playerMember = new List<PlayerChara>();

    public GameObject zainPrefab;

    public bool ActivFlag;

    public int Count;
    

    private int SelectCharacterNum;

    bool AttackFlag = false;
    public void CreateParty()
    {
        playerMember.Add(PlayerItemBox.playerChara[0]);
        playerMember.Add(PlayerItemBox.playerChara[1]);
        playerMember.Add(PlayerItemBox.playerChara[2]);
        enemyMember.Add(new AegisHenchman());
    }
    public void CreateEnemy()
    {
        enemyMember.Add(new AegisHenchman());
    }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
         CreateEnemy();
        CreateParty();
        _ = playerMember[0].Line();
    }
    
    private void FixedUpdate()
    {
        
    }
    public void Finish()
    {
        Debug.Log("I—¹"); 
    }
    public async Task Maneger()
    {
       ActivFlag = true;
       _  = playerMember[0].Line();

        while (true)
        {
            Debug.Log("ˆêƒ^[ƒ“–Ú");
            if(!ActivFlag)
            {
                Finish();
                return;
            }
            else
            {
                await playerMember[Count].Line();
            }
            
            if (Count > playerMember.Count)
            {
                Count = 0;
            }
        }
    }
    public characterBase GiveEnemy()
    {
        return enemyMember[Random.Range(0,enemyMember.Count)];
    }
}
