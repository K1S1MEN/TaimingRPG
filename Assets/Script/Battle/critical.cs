using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

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
    public TextMeshProUGUI nowTurnText;
    
    private GameObject go;
    bool MoveFlag = false;
    float x;
    float y;
    bool     JudgeNum;
    void Start()
    {
        startPos = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y);
    }
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (criticalPoint.anchoredPosition.x + criticalWidth>=this.rect.anchoredPosition.x && MoveFlag)
        {
            this.rect.anchoredPosition = new Vector2(this.rect.anchoredPosition.x+1*speed, this.rect.anchoredPosition.y); 
            
        }
        if (Input.GetKeyDown(KeyCode.Space)&& MoveFlag||Input.GetMouseButton(0)&&MoveFlag)
        {
            MoveFlag = false;
            Judge();
        }
    }

    public async UniTask<bool> ReturnJudge()
    {
        MoveFlag = true;
        nowTurnText.text = "ATTACK TIME";
        while (MoveFlag)
        {
            await UniTask.Yield();
        }
        this.rect.anchoredPosition = startPos;
        return JudgeNum;
        
    }
    void Judge()
    {
        float _ = this.rect.anchoredPosition.x;

        this.rect.anchoredPosition = startPos;
        if (criticalPoint.anchoredPosition.x + criticalWidth > _ && criticalPoint.anchoredPosition.x - criticalWidth < _)
        {
            JudgeNum = true;
            Debug.Log("a");
        }
        else
        {
            JudgeNum = false;
            Debug.Log("NoCritical");
        }


    }
}
