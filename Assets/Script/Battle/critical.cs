using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class critical : MonoBehaviour
{
    public RectTransform criticalPoint;
    public float criticalWidth;
    private float time = 0;
    public float max = 1f;
    public float speed = 0f;
    public float overLine = 1f;
    public RectTransform rect;
    
    private GameObject go;
    bool MoveFlag = true;
    float x;
    float y;
    int JudgeNum;
    void Start()
    {
        go = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (criticalPoint.anchoredPosition.x + criticalWidth>=this.rect.anchoredPosition.x && MoveFlag)
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

    public async UniTask<int> ReturnJudge()
    {
        while (MoveFlag)
        {
            await UniTask.Yield();
        }
        return JudgeNum;
        
    }
    void Judge()
    {
        float _ = this.rect.anchoredPosition.x;
        if (criticalPoint.anchoredPosition.x + criticalWidth > _ && criticalPoint.anchoredPosition.x - criticalWidth < _)
        {
            JudgeNum = 1;
            Debug.Log("a");
        }
        else
        {
            JudgeNum = 0;
            Debug.Log("b");
        }
        Destroy(this.gameObject);


    }
}
