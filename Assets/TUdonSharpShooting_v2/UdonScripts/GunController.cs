using UdonSharp;
using UnityEngine;
using VRC.Udon;
using VRC.SDKBase;

public class GunController : UdonSharpBehaviour
{
    int playerID;
    int ATK;
    int bulletNumMax;
    int bulletNum;

    [SerializeField] Bullet bullet;
    ResetTransform resetPosition;
    DelayTimer delayTimer;
    AudioManager audioManager;
    GameManager gameManager;

    void Start()
    {
        resetPosition = GetComponent<ResetTransform>();
        delayTimer    = GetComponent<DelayTimer>();
        delayTimer.SetTimerCapacity(2);
    }

    public void InitData(int _playerID, int _ATK, int _bulletNumMax)
    {
        playerID     = _playerID;
        ATK          = _ATK;
        bulletNumMax = _bulletNumMax;
        bulletNum    = _bulletNumMax;
        gameManager = transform.root.GetComponent<GameManager>();
        //gameManager.GetScoreManager().SetDataOwnership(Networking.LocalPlayer, playerID);
        audioManager = gameManager.GetAudioManager();
        bullet.InitData(this);
    }

    private void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            if (bulletNum <= 0) return;
            bullet.Shot();
            ShotSE();

            bulletNum--;
            if (bulletNum <= 0)
            {
                delayTimer.StartTimer(0, this, "Reload", 1);
            }
        }
        */
            
    }

    public override void OnPickupUseDown()
    {
        if (bulletNum <= 0) return;
        bullet.Shot();
        ShotSE();

        bulletNum--;
        if (bulletNum <= 0)
        {
            delayTimer.StartTimer(0, this, "Reload", 1);
        }
    }

    public void ShotSE()
    {
        audioManager.PlayShotSE();
    }

    public void Reload()
    {
        bulletNum = bulletNumMax;
        ReloadSE();
    }

    public void ReloadSE()
    {
        audioManager.PlayReloadSE();
    }

    public override void OnPickup()
    {
        delayTimer.StopTimer(0);
        gameManager.GetNameManager().SetNameSync(Networking.LocalPlayer, playerID, Networking.LocalPlayer.displayName);
    }

    public override void OnDrop()
    {
        delayTimer.StartTimer(1, this, "ResetPosition", 3);
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
