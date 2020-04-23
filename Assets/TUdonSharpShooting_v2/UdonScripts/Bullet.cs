
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Bullet : UdonSharpBehaviour
{
    ParticleSystem bullet;
    [SerializeField] ParticleSystem bulletEffect;

    GameManager gameManager;
    GunController gunController;

    public void InitData(GunController _gunController)
    {
        gameManager = transform.root.GetComponent<GameManager>();
        bullet = GetComponent<ParticleSystem>();
        gunController = _gunController;
    }

    public void Shot()
    {
        bullet.Play();
        bulletEffect.Play();
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ShotEffect");
    }

    public void ShotEffect()
    {
        bulletEffect.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        Target target = other.GetComponent<Target>();
        if (target == null) return;

        gameManager.GetScoreManager().AddValue(gunController.GetPlayerID(), target.GetPoint());
        target.Damage(gunController.GetATK());
    }
}
