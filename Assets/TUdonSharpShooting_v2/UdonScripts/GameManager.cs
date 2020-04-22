
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GameManager : UdonSharpBehaviour
{
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        
    }

    public AudioManager GetAudioManager() { return audioManager; }
}
