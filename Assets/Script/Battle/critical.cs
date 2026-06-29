using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class critical : MonoBehaviour
{
    public float criticalJudge = 568f;
    private float time = 0;
    public float max = 1f;
    public float speed = 0f;
    public float overLine = 1f;
    public RectTransform rect;
    private GameObject go;
    bool MoveFlag = true;
    float x;
    float y;
    void Start()
    {
        go = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time <= max && MoveFlag)
        {
            this.rect.anchoredPosition = new Vector2(this.rect.anchoredPosition.x+1*speed, this.rect.anchoredPosition.y); 
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& MoveFlag)
        {
            MoveFlag = false;
            Judge();
        }
    }
    void Judge()
    {
        float _ = this.rect.anchoredPosition.x;
        if (criticalJudge <= _)
        {
            Debug.Log("a");
        }
        else
        {
            Debug.Log("b");
        }
        Destroy(this.gameObject);


    }
}
