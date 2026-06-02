using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChara : characterBase
{
    private float cost = 0f;
    protected void FixedUpdate()
    {
        if (cost < 10f)
        {
            cost += 1 * Time.deltaTime;
        }
        
    }
    public void CriticalCost()
    {
        if(cost <10f)
        {
            cost += 0.3f;
        }
    }
    public virtual void Attack2() { }
    public virtual void Attack3() { }

    public virtual void EXSkill() { }
    public virtual void Skill() { }
}
