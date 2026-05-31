using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class characterBase
{
    public string name;
    public int id;
    public int HP;
    public int Attack;
    public float cost;
    public string Log;

    public virtual void attack()
    {
    
    }
    
}
