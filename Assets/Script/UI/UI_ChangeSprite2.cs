using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ChangeSprite2 : MonoBehaviour
{
    public SpriteRenderer playerBlade1;
    public SpriteRenderer playerBlade2;

    public SpriteRenderer playerAvatar1;
    public SpriteRenderer playerAvatar2;

    

    public Sprite[] bladeSprites;
    public Sprite[] avatarSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerBlade1.sprite = bladeSprites[PublicValue.bladeIndex1];
        playerBlade2.sprite = bladeSprites[PublicValue.bladeIndex2];

        playerAvatar1.sprite = avatarSprites[PublicValue.avatarIndex1];
        playerAvatar2.sprite = avatarSprites[PublicValue.avatarIndex2];
    }
}
