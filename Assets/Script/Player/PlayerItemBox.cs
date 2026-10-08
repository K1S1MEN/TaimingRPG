using UnityEngine;

public static class PlayerInfo
{
    public static string playerStage = "";
    public static Vector2 playerPosition;
    public static PlayerChara[] playerChara = new PlayerChara[3];
    public static bool PlayerStage01Key = false;
    public static bool[] PlayerItems = new bool[3]
    {
        false,true,false
    };

}
