
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Target : UdonSharpBehaviour
{
    [SerializeField] int point;
    [SerializeField] int MaxHP;
    int HP;
    [SerializeField] GameObject visual;
    [SerializeField] Collider collider;

    private void Start()
    {
        HP = MaxHP;
    }

    public void Damage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            BreakTarget();
        }
    }

    void BreakTarget()
    {
        visual.SetActive(false);
        collider.enabled = false;
    }

    void Respown()
    {
        HP = MaxHP;
        visual.SetActive(true);
        collider.enabled = true;
    }

    public int GetPoint() { return point; }
    public int GetMaxHP() { return MaxHP; }
    public int GetHP() { return HP; }
}
