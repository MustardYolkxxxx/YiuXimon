using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChangeSprite : MonoBehaviour
{
    public Image playerBlade1;
    public Image playerBlade2;

    public Image playerAvatar1;
    public Image playerAvatar2;

    public GameManager gameManagerScr;

    public Sprite[] bladeSprites;
    public Sprite[] avatarSprites;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScr = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerBlade1.sprite =bladeSprites[ gameManagerScr.sprite1];
        playerBlade2.sprite = bladeSprites[gameManagerScr.sprite2];

        playerAvatar1.sprite = avatarSprites[ gameManagerScr.avatarSprite1];
        playerAvatar2.sprite = avatarSprites[gameManagerScr.avatarSprite2];
    }
}
