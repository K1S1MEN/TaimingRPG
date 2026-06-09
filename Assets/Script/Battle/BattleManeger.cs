using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int AttackPoint;
    bool EnemyAttackFlag = true;
    EnemyChara Enemy = new AegisHenchman();
    private void Start()
    {
        
    }

    private void Update()
    {
        if (EnemyAttackFlag)
        {
            AttackPoint = Enemy.attack();
            int a  = Random.Range(0, 3);
            PlayerItemBox.playerChara[a].Damage(a);
            EnemyAttack();
        }
    }

    private async Task EnemyAttack() 
    {
        EnemyAttackFlag = false;
        await Task.Delay(Enemy.coolTime);
        EnemyAttackFlag =true;
    }

    public void OnClickButton(PlayerChara chara)
    {
        AttackPoint = chara.attack();
        Enemy.Damage(AttackPoint);
        AttackPoint = 0;
    }
}
