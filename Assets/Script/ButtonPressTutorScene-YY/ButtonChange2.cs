using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonChange2 : MonoBehaviour
{
    public Sprite defaultSprite2;
    public Sprite buttonPressed2;

    public GameObject mask;

    private Image buttonImage;   // 按钮的Image组件

    // Start is called before the first frame update
    void Start()
    {
        mask.SetActive(false);

        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = defaultSprite2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // 检测空格键是否被按下
        {
            if (buttonImage != null)
            {
                buttonImage.sprite = buttonPressed2; // 改变精灵
            }
            mask.SetActive(true);

        }

    }
}
