using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonChangePB2 : MonoBehaviour
{
    public Sprite defaultSpritePB2;
    public Sprite buttonPressedPB2;

    public GameObject mask;

    private Image buttonImage;   // 按钮的Image组件

    // Start is called before the first frame update
    void Start()
    {
        mask.SetActive(false);

        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = defaultSpritePB2;
        }
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // 检测空格键是否被按下
        {
            if (buttonImage != null)
            {
                buttonImage.sprite = buttonPressedPB2; // 改变精灵
            }
            mask.SetActive(true);

        }

    }
}
