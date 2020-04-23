
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class TimeText : UdonSharpBehaviour
{
    Text text;
    GameManager gameManager;

    void Start()
    {
        text = GetComponent<Text>();
        gameManager = transform.root.GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gameManager.GetTimeManager().IsStart())
        {
            text.text = gameManager.GetTimeManager().GetTimeInt().ToString();
        }
        else
        {
            text.text = "";
        }
    }
}
