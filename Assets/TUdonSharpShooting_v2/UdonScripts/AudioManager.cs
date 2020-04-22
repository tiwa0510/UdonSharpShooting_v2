
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AudioManager : UdonSharpBehaviour
{
    [SerializeField] AudioSource audioSourceBGM;
    [SerializeField] AudioSource audioSourcesSE;

    [SerializeField] AudioClip TitleBGM;
    [SerializeField] AudioClip GameBGM;
    [SerializeField] AudioClip ClimaxBGM;

    [SerializeField] AudioClip StartGameSE;
    [SerializeField] AudioClip ClimaxSE;
    [SerializeField] AudioClip EndGameSE;

    [SerializeField] AudioClip ShotSE;
    [SerializeField] AudioClip ReloadSE;
    [SerializeField] AudioClip HitSE;

    public void PlayTitleBGM()
    {
        audioSourceBGM.clip = TitleBGM;
        audioSourceBGM.Play();
    }

    public void PlayGameBGM()
    {
        audioSourceBGM.clip = GameBGM;
        audioSourceBGM.Play();
    }

    public void PlayClimaxBGM()
    {
        audioSourceBGM.clip = ClimaxBGM;
        audioSourceBGM.Play();
    }

    public void PlayShotSE()
    {
        audioSourcesSE.PlayOneShot(ShotSE);
    }

    public void PlayReloadSE()
    {
        audioSourcesSE.PlayOneShot(ReloadSE);
    }

    public void PlayHitSE()
    {
        audioSourcesSE.PlayOneShot(HitSE);
    }

    public void PlayStartGameSE()
    {
        audioSourcesSE.PlayOneShot(StartGameSE);
    }

    public void PlayClimaxSE()
    {
        audioSourcesSE.PlayOneShot(ClimaxSE);
    }

    public void PlayEndGameSE()
    {
        audioSourcesSE.PlayOneShot(EndGameSE);
    }
}
