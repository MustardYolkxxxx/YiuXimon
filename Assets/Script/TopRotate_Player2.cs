using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotate_Player2 : MonoBehaviour
{
    public float rotateSpeed;

    public float rotateSpeedDown;
    public float maxRotateSpeedDown;
    public float originRotateSpeedDown =1;


    public Transform trans;

    public float originMaxRotateSpeed;
    [SerializeField] public float maxRotateSpeed;

    public GameManager gameManagerScr;

    public SpriteRenderer sprite;
    public SpriteRenderer avatarSprite;

    public Sprite[] sprites;
    public Sprite[] avatarSprites;
    //public TopDictionary topDicScr;

    public TopMove_Player2 movePlayerScr;
    //public UI_BladeChoose2 bladeChooseScr;
    public float speedUpRate;
    [SerializeField] public float maxSpeedUpRate;
    public float originSpeedUpRate;


    // Start is called before the first frame update
    void Start()
    {
        rotateSpeedDown = originRotateSpeedDown;
        speedUpRate = originSpeedUpRate;
        maxRotateSpeed = originMaxRotateSpeed;
        trans = gameObject.GetComponent<Transform>();
        //topDicScr = FindObjectOfType<TopDictionary>();
        gameManagerScr = FindObjectOfType<GameManager>();

        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[gameManagerScr.sprite2];

        avatarSprite.sprite = avatarSprites[gameManagerScr.avatarSprite2];
        
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        maxRotateSpeedDown = gameManagerScr.bladeSpeedDownRate2;
        rotateSpeedDown = originRotateSpeedDown + maxRotateSpeedDown;

        maxSpeedUpRate = gameManagerScr.blade2SpeedUpRate;
        speedUpRate = originSpeedUpRate + maxSpeedUpRate;

        trans.rotation *= Quaternion.Euler(0, 0, rotateSpeed);
        rotateSpeed -= rotateSpeedDown * Time.deltaTime;
        maxRotateSpeed = originMaxRotateSpeed + gameManagerScr.bladeMaxSpeed2;

       

        CheckRotateSpeed();
    }


    void CheckRotateSpeed()
    {
        if (rotateSpeed < 0)
        {
            rotateSpeed = 0;
        }

        if (rotateSpeed > maxRotateSpeed)
        {
            rotateSpeed = maxRotateSpeed;
        }
    }

    public void SpeedUp()
    {
        rotateSpeed += speedUpRate;
    }
}
