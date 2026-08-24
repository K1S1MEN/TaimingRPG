using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    public Animator animator;

    public float speed = 3;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(x * Time.deltaTime*speed, y * Time.deltaTime*speed, 0);
        if (x != 0 || y != 0)
        {
            if (Random.Range(0, 150) == 0)
            {
                PlayerInfo.playerStage = SceneManager.GetActiveScene().name;
                PlayerInfo.playerPosition = new Vector2(x,y);
                Debug.Log("エンカウント！！");
                EncounterSystem.StartBattle();
            }

        }
    }
}
