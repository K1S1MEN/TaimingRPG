using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterSystem : MonoBehaviour
{
    static List<int> enemyCharas = new List<int>();
    static public void StartBattle()
    {
        for (int i = 0; i < Random.Range(0, 3); i++)
        {
            enemyCharas.Add(Random.Range(0, 2));
        }

        SceneManager.LoadScene("MainBattelScene");
    }
}
