using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
[CreateAssetMenu(menuName = "Character Base")]
public class characterBase : ScriptableObject
{
    public characterBase Prefab;
    [Header("value")]
    public string Name;
    public int id;
    public int HP;
    public int maxHP;
    public int dif;
    public int Attack;
    protected int AttackPoint;
    public string Log;


    public virtual void  attack(characterBase target)
    {
        AttackPoint = Attack;
        target.Damage(AttackPoint);
    }

    public virtual void Damage(int ATP)
    {
        HP -= ATP - dif;
        if (HP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

        Destroy(this);
    }

}
