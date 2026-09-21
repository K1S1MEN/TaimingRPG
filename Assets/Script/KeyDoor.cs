using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    public string RoomName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            if (PlayerInfo.PlayerStage01Key)
            {
                SceneManager.LoadScene(RoomName);
            }
        }
    }
}
