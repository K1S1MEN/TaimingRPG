using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Animator animator;

    private void InCurtain()
    {
        animator.SetTrigger("In");
    }

    private void OutCurtain()
    {
        animator.SetTrigger("Out");
    }
}
