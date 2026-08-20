using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerMove : MonoBehaviour
{
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
                Debug.Log("エンカウント！！");
            }

        }
    }
}
