using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotate_Player1 : MonoBehaviour
{
    public float rotateSpeed;

    public float rotateSpeedDown;
    public float maxRotateSpeedDown;
    public float originRotateSpeedDown =1;

    public Transform trans;

    public float originMaxRotateSpeed;

    [SerializeField] public float maxRotateSpeed;

    public SpriteRenderer sprite;

    public SpriteRenderer avatarSprite;

    public Sprite[] sprites;
    public Sprite[] avatarSprites;

    public TopMove_Player1 movePlayerScr;
    
    //public TopDictionary topDicScr;

    //public UI_BladeChoose1 bladeChooseScr;
    public float speedUpRate;
    [SerializeField] public float maxSpeedUpRate;
    public float originSpeedUpRate;

    public GameManager gameManagerScr;


    // Start is called before the first frame update
    void Start()
    {

        
        speedUpRate = originSpeedUpRate;
        
        trans = gameObject.GetComponent<Transform>();

        gameManagerScr = FindObjectOfType<GameManager>();

        sprite = gameObject.GetComponent<SpriteRenderer>();

        sprite.sprite = sprites[gameManagerScr.sprite1];
        avatarSprite.sprite = avatarSprites[gameManagerScr.avatarSprite1];
        //topDicScr = FindObjectOfType<TopDictionary>();
        //bladeChooseScr = FindObjectOfType<UI_BladeChoose1>();
    }

    private void FixedUpdate()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        
        maxRotateSpeedDown = gameManagerScr.bladeSpeedDownRate1;
        rotateSpeedDown = originRotateSpeedDown + maxRotateSpeedDown;

        speedUpRate = originSpeedUpRate + maxSpeedUpRate;
        trans.rotation*= Quaternion.Euler(0,0, rotateSpeed);
        rotateSpeed -= rotateSpeedDown*Time.deltaTime;

        maxRotateSpeed = originMaxRotateSpeed + gameManagerScr.bladeMaxSpeed1;

        CheckRotateSpeed();
    }



    void CheckRotateSpeed()
    {
        if(rotateSpeed < 0)
        {
            rotateSpeed= 0;
        }

        if (rotateSpeed >maxRotateSpeed)
        {
            rotateSpeed = maxRotateSpeed;
        }
    }

   public void SpeedUp()
    {
        rotateSpeed += speedUpRate;
    }
}
