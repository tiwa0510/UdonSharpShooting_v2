
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class MasterNameText : UdonSharpBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = Networking.GetOwner(gameObject).displayName;
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        text.text = Networking.GetOwner(gameObject).displayName;
    }
}
