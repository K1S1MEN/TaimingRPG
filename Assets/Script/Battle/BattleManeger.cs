using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    void CreateParty()
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Chara/" + PlayerInfo.playerChara[0]);
        if (playerPrefab != null) Instantiate(playerPrefab);
    }
    public void CreateEnemy()
    {
        for (int x = 0; x < EncounterSystem.enemyCharasID.Count; x++)
        {
            GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Enemy/" + CastForEnemy.Instance.RetunEnemyName(EncounterSystem.enemyCharasID[x]));
            if (playerPrefab != null) Instantiate(playerPrefab);
        }
        
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
            await enemyMember[i].Loop();

            if (playerMember.Count < 0)
            {
                _ =  Finish();
                break;
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _ = Fade.Instance.FadeOut();
        _ = Maneger();
        StartEnemyAttack();
    }

    private void FixedUpdate()
    {

    }
    public async Task Finish()
    {
        await Fade.Instance.FadeIn();
        SceneManager.LoadScene(PlayerInfo.playerStage);
    }
    public async Task Maneger()
    {
        ActivFlag = true;

        while (true)
        {
            if (enemyMember.Count <= 0)
            {
                _ = Finish();
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
        return enemyMember[Random.Range(0, enemyMember.Count)];
    }
    public PlayerChara GivePlayer()
    {
        return playerMember[Random.Range(0, playerMember.Count)];
    }

    private void CheckEnemy()
    {
        if (enemyMember.Count <= 0)
        {
            _ = Finish();
        }
    }


}
