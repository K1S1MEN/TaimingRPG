using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
[CreateAssetMenu(menuName = "Character Base")]
public class characterBase : MonoBehaviour
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


    public virtual bool  attack(characterBase target)
    {
        AttackPoint = Attack;
        return true;
    }

    public int Judgment()
    {
        return 0;
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
