using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    public string RoomName;
    private void OnCollisionEnter(Collision collision)
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
