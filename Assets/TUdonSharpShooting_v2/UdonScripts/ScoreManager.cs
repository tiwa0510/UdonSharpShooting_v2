
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ScoreManager : UdonSharpBehaviour
{
    ScoreData[] scoreData;

    void Start()
    {
        scoreData = new ScoreData[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            scoreData[i] = transform.GetChild(i).GetComponent<ScoreData>();
        }

        ResetScore();
    }

    public void ResetScore()
    {
        for (int i = 0; i < scoreData.Length; i++)
        {
            scoreData[i].SetValue(0);
        }
    }

    public void SetValue(int playerID, int score)
    {
        scoreData[playerID].SetValue(score);
    }

    public void AddValue(int playerID, int score)
    {
        scoreData[playerID].AddValue(score);
    }

    public int GetData(int playerID)
    {
        if (scoreData == null) return 0;
        return scoreData[playerID].GetValue();
    }

    public void SetDataOwnership(VRCPlayerApi player, int playerID)
    {
        Networking.SetOwner(player, scoreData[playerID].gameObject);
    }
}
