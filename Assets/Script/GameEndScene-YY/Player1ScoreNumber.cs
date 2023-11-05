using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player1ScoreNumber : MonoBehaviour
{
    public int Player1Score;
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
        textMeshProUGUI.text = Player1Score.ToString();
    }

    public void ChangeNumber(int newNumber)
    {
        Player1Score = newNumber;
    }
}