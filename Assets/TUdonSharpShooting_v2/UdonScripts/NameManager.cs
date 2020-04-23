
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NameManager : UdonSharpBehaviour
{
    NameData[] nameData;
    DelayTimer delayTimer;

    VRCPlayerApi tPlayer;
    string tName = "";
    int tID = -1;

    private void Start()
    {
        delayTimer = GetComponent<DelayTimer>();
        delayTimer.SetTimerCapacity(1);

        nameData = new NameData[transform.childCount];
        Debug.Log(nameData);
        for (int i = 0; i < transform.childCount; i++)
        {
            nameData[i] = transform.GetChild(i).GetComponent<NameData>();
        }

        ResetName();
    }

    public void ResetName()
    {
        for (int i = 0; i < nameData.Length; i++)
        {
            nameData[i].SetValue((i + 1).ToString() + "P");
        }
    }

    public void SetNameSync(VRCPlayerApi player, int playerID, string name)
    {
        if (!Networking.IsOwner(player, nameData[playerID].gameObject))
        {
            Networking.SetOwner(player, nameData[playerID].gameObject);
            tPlayer = player;
            tID = playerID;
            tName = name;
            delayTimer.StartTimer(0, this, "SetName", 0.5f);
        }
        else
        {
            nameData[playerID].SetValue(name);
            tPlayer = null;
            tID = -1;
            tName = "";
        }
    }

    public string GetData(int playerID)
    {
        if (nameData == null) return "";
        return nameData[playerID].GetValue();
    }

    public void SetDataOwnership(VRCPlayerApi player, int playerID)
    {
        Networking.SetOwner(player, nameData[playerID].gameObject);
    }
}
