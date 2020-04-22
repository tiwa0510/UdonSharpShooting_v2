
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ScoreText : UdonSharpBehaviour
{
    Text scoreText;
    [SerializeField] int playerID;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = gameManager.GetScoreManager().GetData(playerID).GetValue().ToString();
    }
}
