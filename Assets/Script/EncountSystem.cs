using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterSystem : MonoBehaviour
{
    public static List<int> enemyCharasID = new List<int>();
    public static EncounterSystem Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        enemyCharasID.Add(0);

    }
    static public void StartBattle()
    {
       for (int i = 0; i < Random.Range(0, 3); i++)
        {
            enemyCharasID.Add(Random.Range(0, 2));
        }

        SceneManager.LoadScene("MainBattelScene");
    }
}
