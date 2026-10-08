using UnityEngine;

public class PlayerInfo:MonoBehaviour
{
    public static PlayerInfo Instance;
    public static string playerStage = "";
    public static Vector2 playerPosition;
    public static PlayerChara[] playerChara = new PlayerChara[3];
    public static bool PlayerStage01Key = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
