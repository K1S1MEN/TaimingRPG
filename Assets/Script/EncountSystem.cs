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

    }
    static public void StartBattle()
    {
        enemyCharasID.Clear();
        int random = Random.Range(1, 4);
        for (int i = 0; i < random; i++)
        {
            enemyCharasID.Add(Random.Range(0, 2));
        }


        SceneManager.LoadScene("MainBattelScene");
    }
}
