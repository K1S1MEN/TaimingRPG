using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string stage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "Player")
        {
            LoadSence();
        }
    }

    public void LoadSence()
    {
        SceneManager.LoadScene(stage);
    }
}
