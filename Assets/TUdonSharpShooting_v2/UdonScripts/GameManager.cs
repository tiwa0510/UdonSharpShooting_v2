
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GameManager : UdonSharpBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] NameManager nameManager;
    [SerializeField] TimeManager timeManager;

    void Start()
    {
        
    }

    public AudioManager GetAudioManager() { return audioManager; }
    public ScoreManager GetScoreManager() { return scoreManager; }
    public NameManager GetNameManager() { return nameManager; }
    public TimeManager GetTimeManager() { return timeManager; }
}
