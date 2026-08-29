using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class Fade : MonoBehaviour
{
    [SerializeField] Image image;
    public float fadeSpeed;
    bool In = false;
    bool Out = false;
    public static Fade Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public async UniTask FadeOut()
    {
        while (image.color.a > 0.0f)
        {
            Color c = image.color;
            c.a -= fadeSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);
            image.color = c;
            await UniTask.Yield();
        }
    }

    public async UniTask FadeIn()
    {
        while (image.color.a < 0.99f)
        {
            Color c = image.color;
            c.a += fadeSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);
            image.color = c;

            await UniTask.Yield();

        }
    }
}
