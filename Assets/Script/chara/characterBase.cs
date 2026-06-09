using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class characterBase : MonoBehaviour
{
    protected string Name;
    protected int id;//0はサンプル、1~100がプレイアブル　200 ~ が敵モンスター
    protected int HP;
    protected int maxHP;
    protected int dif;
    protected int Attack;
    protected int AttackPoint;
    protected string Log;

    public virtual int attack()
    {
        AttackPoint = Attack;
        return AttackPoint;
    }

    public virtual void Damage(int ATP)
    {
        HP = ATP - dif;
        if (HP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }

}
