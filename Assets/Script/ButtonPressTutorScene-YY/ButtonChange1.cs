using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange1 : MonoBehaviour
{
    public Sprite defaultSprite1; 
    public Sprite buttonPressed1;

    private Image buttonImage;   // 按钮的Image组件

    public GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
        mask.SetActive(false); 
         buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = defaultSprite1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 检测空格键是否被按下
        {
            if (buttonImage != null)
            {
                buttonImage.sprite = buttonPressed1; // 改变精灵
            }
            mask.SetActive(true);

        }

    }
}
