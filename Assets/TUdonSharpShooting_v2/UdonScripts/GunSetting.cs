
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GunSetting : UdonSharpBehaviour
{
    [SerializeField] int bulletNumMax;
    [SerializeField] int ATK;
    [SerializeField] GameObject guns;

    void Start()
    {
        Init();
    }

    void Init()
    {
        for(int i = 0; i < guns.transform.childCount; i++)
        {
            guns.transform.GetChild(i).GetComponent<GunController>().InitData(i, ATK, bulletNumMax);
        }
    }
}
