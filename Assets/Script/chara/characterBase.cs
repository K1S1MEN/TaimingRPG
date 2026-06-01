using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class characterBase:MonoBehaviour
{
    public string Name;
    public int id;//0はサンプル、1~100がプレイアブル　200 ~ が敵モンスター
    public int HP;
    public  int maxHP;
    public int Attack;
    public string Log;

    public virtual void attack()
    {
    
    }
    
}
