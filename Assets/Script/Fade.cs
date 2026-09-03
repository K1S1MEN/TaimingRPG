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
        DontDestroyOnLoad(transform.root.gameObject);
    }

    public async UniTask FadeOut()
    {
        var token = this.GetCancellationTokenOnDestroy();

        while (!token.IsCancellationRequested && image != null && image.color.a > 0f)
        {
            Color c = image.color;
            c.a -= fadeSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);

            if (image == null) return;
            image.color = c;

            await UniTask.Yield(token);
        }
    }

    public async UniTask FadeIn()
    {
        var token = this.GetCancellationTokenOnDestroy();
        while (!token.IsCancellationRequested && image.color.a < 0.99f)
        {
            Color c = image.color;
            c.a += fadeSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);
            image.color = c;

            await UniTask.Yield(token);

        }
    }
}
