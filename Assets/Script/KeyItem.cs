using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a");
        if (collision.gameObject.tag == "player")
        {
            PlayerInfo.PlayerStage01Key = true;
            Destroy(this.gameObject);
        }
    }
}
