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

    private bool ActivFlag;

    private int Count;

    public TextMeshProUGUI nowTurnText;

    private int TurnCount;
    [SerializeField] private Transform enemySpawnPoint1;
    [SerializeField] private Transform enemySpawnPoint2;
    [SerializeField] private Transform enemySpawnPoint3;
    public void CreateEnemy()
    {
        for (int x = 0; x < EncounterSystem.enemyCharasID.Count; x++)
        {
            EnemyChara EnemyPrefab = Resources.Load<EnemyChara>("Enemy/" + CastForEnemy.Instance.RetunEnemyName(EncounterSystem.enemyCharasID[x]));
            if (EnemyPrefab != null)
            {
                EnemyChara enemy;
                switch (x)
                {
                    case 0:
                        enemy = Instantiate(EnemyPrefab, enemySpawnPoint1.position, enemySpawnPoint1.rotation);
                        enemyMember.Add(enemy);
                        break;
                    case 1:
                        enemy = Instantiate(EnemyPrefab, enemySpawnPoint2.position, enemySpawnPoint2.rotation);
                        enemyMember.Add(enemy);
                        break;
                    case 2:
                        enemy = Instantiate(EnemyPrefab, enemySpawnPoint3.position, enemySpawnPoint3.rotation);
                        enemyMember.Add(enemy);
                        break;


                }


            }
            else
            {
                Debug.LogError("“GPrefab‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
            }

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
        while (i < enemyMember.Count)
        {
            await enemyMember[i].Loop();
        }

    }
    private void Awake()
    {
        Instance = this;
    }

    private async void  Start()
    {

        await Fade.Instance.FadeOut();
        CreateEnemy();
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
}
