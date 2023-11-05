using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_PlayerScore : MonoBehaviour
{

    public GameManager GameManagerScr;
    public TextMeshProUGUI playerScore1;
    public TextMeshProUGUI playerScore2;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerScr = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScore1.text = GameManagerScr.player1Score.ToString();
        playerScore2.text = GameManagerScr.player2Score.ToString();

       
    }
}
