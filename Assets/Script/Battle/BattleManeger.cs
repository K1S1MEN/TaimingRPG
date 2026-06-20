using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public List<EnemyChara> enemyMember = new List<EnemyChara>();

    public List<PlayerChara> playerMember = new List<PlayerChara>();

    public GameObject zainPrefab;

    public List<PlayerChara> AttackLine = new List<PlayerChara>();

    public void CreateParty()
    {
        playerMember.Add(PlayerItemBox.playerChara[0]);
        playerMember.Add(PlayerItemBox.playerChara[1]);
        playerMember.Add(PlayerItemBox.playerChara[2]);
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

    public void PlayerAttack()
    {
        playerMember[0].attack(enemyMember[Random.Range(0, enemyMember.Count + 1)]);
    }
    public async Task<bool> AttackCoolTime(int waitTime)
    {
        await Task.Delay(waitTime);
        return true;
    }


}
