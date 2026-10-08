using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    public string RoomName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "player")
        {

            if (PlayerInfo.PlayerStage01Key == true)
            {
                SceneManager.LoadScene(RoomName);
            }
        }
    }
}
