using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2ScoreNumber : MonoBehaviour
{
    public int Player2Score;
    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        if (textMeshProUGUI == null)
        {
            Debug.LogError("TextMeshProUGUI component not set on " + gameObject.name);
        }
    }

    void Update()
    {
        textMeshProUGUI.text = Player2Score.ToString();
        ChangeNumber(PublicValue.playerScore2);
    }

    public void ChangeNumber(int newNumber)
    {
        Player2Score = newNumber;
    }
}
