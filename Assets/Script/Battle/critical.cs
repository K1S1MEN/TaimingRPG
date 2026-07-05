using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class critical : MonoBehaviour
{
    public static critical Instance;
    public RectTransform criticalPoint;
    public float criticalWidth;
    public float max = 1f;
    public float speed = 0f;
    public float overLine = 1f;
    public RectTransform rect;
    private Vector2 startPos;
    
    private GameObject go;
    bool MoveFlag = false;
    float x;
    float y;
    bool     JudgeNum;
    void Start()
    {
        go = this.gameObject;
        startPos = transform.position;
    }
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (criticalPoint.anchoredPosition.x + criticalWidth>=this.rect.anchoredPosition.x && MoveFlag)
        {
            this.rect.anchoredPosition = new Vector2(this.rect.anchoredPosition.x+1*speed, this.rect.anchoredPosition.y); 
            
        }
        if (Input.GetKeyDown(KeyCode.Space)&& MoveFlag)
        {
            MoveFlag = false;
            Judge();
        }
    }

    public async UniTask<bool> ReturnJudge()
    {
        Debug.Log("リターンジャッジ");
        MoveFlag = true;
        while (MoveFlag)
        {
            Debug.Log("応答待ち");
            await UniTask.Yield();
        }
        this.rect.anchoredPosition = startPos;
        return JudgeNum;
        
    }
    void Judge()
    {
        float _ = this.rect.anchoredPosition.x;
        if (criticalPoint.anchoredPosition.x + criticalWidth > _ && criticalPoint.anchoredPosition.x - criticalWidth < _)
        {
            JudgeNum = true;
            Debug.Log("a");
        }
        else
        {
            JudgeNum = false;
            Debug.Log("b");
        }


    }
}
