
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ScoreManager : UdonSharpBehaviour
{
    [SerializeField] ScoreData[] scoreData;

    void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        for (int i = 0; i < scoreData.Length; i++)
        {
            scoreData[i].SetValue(0);
        }
    }

    public ScoreData GetData(int playerID)
    {
        return scoreData[playerID];
    }

    public void SetDataOwnership(VRCPlayerApi player, int playerID)
    {
        Networking.SetOwner(player, scoreData[playerID].gameObject);
    }
}
