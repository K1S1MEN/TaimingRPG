using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
public class EnemyData
{
    public int ID;
    public string Name;
    public string ResourceName;
}
public class CastForEnemy : MonoBehaviour
{
    [SerializeField]
    private TextAsset enemyCSV;
    public List<EnemyData> enemyDataList = new List<EnemyData>();
    public static CastForEnemy Instance;
    void Start()
    {

    }
    private void Awake()
    {
        Instance = this;
        LoadCSV();
    }


    private void LoadCSV()
    {
        string[] lines = enemyCSV.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] values = lines[i].Trim().Split(',');

            EnemyData data = new EnemyData();

            data.ID = int.Parse(values[1]);
            data.Name = values[0];
            data.ResourceName = values[2];

            enemyDataList.Add(data);
        }

        
    }


    public string RetunEnemyName(int a)
    {
        string _;
        _ = enemyDataList[a].ResourceName;
        return _;
    }
}
