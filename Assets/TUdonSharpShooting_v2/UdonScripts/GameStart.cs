
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GameStart : UdonSharpBehaviour
{
    GameManager gameManager;
    Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = Networking.IsMaster;

        gameManager = transform.root.GetComponent<GameManager>();
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        collider.enabled = Networking.IsMaster;
    }

    public override void Interact()
    {
        gameManager.GetTimeManager().StartTimeCount();
    }
}
