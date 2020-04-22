using UdonSharp;
using UnityEngine;

public class GunController : UdonSharpBehaviour
{
    int playerID;
    int ATK;
    int bulletNumMax;
    int bulletNum;

    ResetTransform resetPosition;
    DelayTimer delayTimer;
    ParticleSystem bullet;
    ParticleSystem bulletEffect;
    GameManager gameManager;
    AudioManager audioManager;

    void Start()
    {
        resetPosition = GetComponent<ResetTransform>();
        delayTimer    = GetComponent<DelayTimer>();
        bullet        = GetComponent<ParticleSystem>();
        bulletEffect  = bullet.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    public void InitData(int _playerID, int _ATK, int _bulletNumMax, GameManager _gameManager)
    {
        playerID     = _playerID;
        ATK          = _ATK;
        bulletNumMax = _bulletNumMax;
        bulletNum    = _bulletNumMax;
        gameManager  = _gameManager;
        audioManager = gameManager.GetAudioManager();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (bulletNum <= 0) return;
            bullet.Play();
            ShotSE();
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ShotEffect");

            bulletNum--;
            Debug.Log(bulletNum);
            Debug.Log(bulletNumMax);
            if (bulletNum <= 0)
            {
                delayTimer.StartTimer("Reload", 1);
            }
        }
            
    }

    public override void OnPickupUseDown()
    {
        if (bulletNum <= 0) return;
        bullet.Play();
        ShotSE();
        SendCustomNetworkEvent( VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ShotEffect");

        bulletNum--;
        if (bulletNum <= 0)
        {
            delayTimer.StartTimer("Reload", 1);
        }
    }

    public void ShotEffect()
    {
        bulletEffect.Play();
    }

    public void ShotSE()
    {
        audioManager.PlayShotSE();
    }

    public void Reload()
    {
        bulletNum = bulletNumMax;
        Debug.LogError(bulletNum);
        ReloadSE();
    }

    public void ReloadSE()
    {
        audioManager.PlayReloadSE();
    }

    public override void OnPickup()
    {
        delayTimer.StopTimer(0);
    }

    public override void OnDrop()
    {
        delayTimer.StartTimer("ResetPosition", 3);
    }

    public void ResetPosition()
    {
        resetPosition.Execute();
    }

    // getter
    public int GetPlayerID()     { return playerID; }
    public int GetATK()          { return ATK; }
    public int GetBulletNum()    { return bulletNum; }
    public int GetBulletNumMax() { return bulletNumMax; }
}
