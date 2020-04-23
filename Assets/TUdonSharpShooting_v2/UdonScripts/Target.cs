
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Target : UdonSharpBehaviour
{
    [SerializeField] int point;
    [SerializeField] int MaxHP;
    int HP;
    [SerializeField] Animator animator;
    [SerializeField] GameObject visual;
    [SerializeField] Collider collider;
    [SerializeField] ParticleSystem breakEffect;
    [SerializeField] ParticleSystem addScoreEffect;

    GameManager gameManager;
    [SerializeField] float start;
    [SerializeField] float end;
    DelayTimer delayTimer;
    [SerializeField] float respownIntervalTime;

    bool isActiveTime;

    private void Start()
    {
        HP = MaxHP;
        gameManager = transform.root.GetComponent<GameManager>();
        delayTimer = GetComponent<DelayTimer>();
        delayTimer.SetTimerCapacity(2);
        DisableTarget();
    }

    private void Update()
    {
        float time = gameManager.GetTimeManager().GetTime();
        if (start >= time && time >= end + animator.GetCurrentAnimatorStateInfo(0).length)
        {
            if (!isActiveTime)
            {
                isActiveTime = true;
                RespownTarget();
            }
        }
        else
        {
            if (isActiveTime)
            {
                delayTimer.StopTimer(0);
                isActiveTime = false;
                DespownTarget();
            }
        }
    }

    public void Damage(int damage)
    {
        addScoreEffect.Play();
        HP -= damage;
        if(HP <= 0)
        {
            BreakTarget();
        }
    }

    public void BreakTarget()
    {
        breakEffect.Play();
        DisableTarget();
        delayTimer.StartTimer(0, this, "RespownTarget", respownIntervalTime);
    }

    void DespownTarget()
    {
        animator.Play("Rotate", 0, 0);
        delayTimer.StartTimer(1, this, "DisableTarget", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void DisableTarget()
    {
        visual.SetActive(false);
        collider.enabled = false;
    }

    public void RespownTarget()
    {
        TargetRotate();
        HP = MaxHP;
        visual.SetActive(true);
        collider.enabled = true;
    }

    public void TargetRotate()
    {
        animator.Play("Rotate", 0, 0);
    }

    public int GetPoint() { return point; }
    public int GetMaxHP() { return MaxHP; }
    public int GetHP() { return HP; }
}
