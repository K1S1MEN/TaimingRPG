using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public List<PlayerChara> AttackLine = new List<PlayerChara>();

    public int charaCoolTime = 1000;

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
    }
    
    private void FixedUpdate()
    {
        
    }

    public characterBase GiveEnemy()
    {
        return enemyMember[Random.Range(0,enemyMember.Count)];
    }
}
