using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class BulletCounter : UdonSharpBehaviour
{
    [SerializeField] GunController gunController;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "";
        for (int i = 0; i < gunController.GetBulletNum(); i++)
        {
            text.text += "■";
        }
    }
}