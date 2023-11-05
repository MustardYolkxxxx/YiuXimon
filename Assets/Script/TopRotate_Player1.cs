using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotate_Player1 : MonoBehaviour
{
    public float rotateSpeed;

    public float rotateSpeedDown;
    public Transform trans;

    public float originMaxRotateSpeed;

    [SerializeField] public float maxRotateSpeed;
    

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
        maxRotateSpeed = originMaxRotateSpeed;
        trans = gameObject.GetComponent<Transform>();
        gameManagerScr = FindObjectOfType<GameManager>();
        //topDicScr = FindObjectOfType<TopDictionary>();
        //bladeChooseScr = FindObjectOfType<UI_BladeChoose1>();
    }

    private void FixedUpdate()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        speedUpRate = originSpeedUpRate + maxSpeedUpRate;
        trans.rotation*= Quaternion.Euler(0,0, rotateSpeed);
        rotateSpeed -= rotateSpeedDown*Time.deltaTime;
        maxRotateSpeed = originMaxRotateSpeed + gameManagerScr.bladeMaxSpeed2;

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
