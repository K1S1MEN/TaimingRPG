using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.transform.tag == "Player")
        {
            PlayerInfo.PlayerStage01Key = true;
            Destroy(this.gameObject);
        }
    }
}
