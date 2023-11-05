using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeTT : MonoBehaviour
{
    public Sprite defaultSpriteTT;
    public Sprite buttonPressedTT;


    private Image buttonImageTT;
    // Start is called before the first frame update
    void Start()
    {
        buttonImageTT = GetComponent<Image>();
        if (buttonImageTT != null)
        {
            buttonImageTT.sprite = defaultSpriteTT;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown (KeyCode.Space)) 
        {
            if (buttonImageTT != null)
            {
                buttonImageTT.sprite = buttonPressedTT; // 改变精灵
            }
        }
    }
}
