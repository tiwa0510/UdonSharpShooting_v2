
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ScoreData : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    int score;

    public void SetValue(int value)
    {
        score = value;
    }

    public void AddValue(int value)
    {
        score += value;
    }

    public int GetValue()
    {
        return score;
    }
}
