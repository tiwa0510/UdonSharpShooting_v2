
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NameData : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    string playerName;

    public void SetValue(string value)
    {
        playerName = value;
    }

    public string GetValue()
    {
        return playerName;
    }
}
