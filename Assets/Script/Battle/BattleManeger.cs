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
    [SerializeField]
    private zain zainPrefab;

    public bool ActivFlag;

    public int Count;

    public TextMeshProUGUI nowTurnText;
    

    private int SelectCharacterNum;

    bool AttackFlag = false;
    public void CreateParty()
    {
        playerMember.Add(Instantiate(zainPrefab));
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
        Debug.Log("I—¹"); 
    }
    public async Task Maneger()
    {
       ActivFlag = true;

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
                nowTurnText.text = "COOL TIME";
                await playerMember[Count].Line();
            }
            Count++;
            if (Count >= playerMember.Count)
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
