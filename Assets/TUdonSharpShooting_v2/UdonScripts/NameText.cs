
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class NameText : UdonSharpBehaviour
{
    [SerializeField] int playerID;
    Text scoreText;
    GameManager gameManager;

    private void Start()
    {
        gameManager = transform.root.GetComponent<GameManager>();
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = gameManager.GetNameManager().GetData(playerID);
    }
}
