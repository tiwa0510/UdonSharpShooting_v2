
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GunSetting : UdonSharpBehaviour
{
    [SerializeField] int bulletNumMax;
    [SerializeField] int ATK;
    [SerializeField] GunController[] guns;

    void Start()
    {
        Init();
    }

    void Init()
    {
        for(int i = 0; i < guns.Length; i++)
        {
            guns[i].InitData(i, ATK, bulletNumMax);
        }
    }
}
