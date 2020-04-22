
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GameManager : UdonSharpBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] ScoreManager scoreManager;

    void Start()
    {
        
    }

    public AudioManager GetAudioManager() { return audioManager; }
    public ScoreManager GetScoreManager() { return scoreManager; }
}
