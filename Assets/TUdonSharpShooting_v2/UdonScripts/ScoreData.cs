
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ScoreData : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    int scoreData;

    public void SetValue(int value)
    {
        scoreData = value;
    }

    public int GetValue()
    {
        return scoreData;
    }
}
