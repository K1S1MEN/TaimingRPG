using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class critical : MonoBehaviour
{
    public float criticalJudge = 568f;
    public float time = 0;
    public float max = 1f;
    public float speed = 0f;
    public RectTransform rect;
    bool MoveFlag = true;
    float x;
    float y;
    void Start()
    {
        x = rect.anchoredPosition.x;
        y = rect.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time <= max && MoveFlag)
        {
            this.rect.anchoredPosition = new Vector2(this.rect.anchoredPosition.x+time * speed, this.rect.anchoredPosition.y);
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
    }
}
