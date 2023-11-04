using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMove_Player1 : MonoBehaviour
{
    public float currentMoveSpeed;
    public float currentMoveSpeedHorizontal;

    public float maxMoveSpeed;
    public float maxMoveSpeed_Vertical;
    public float maxMoveSpeed_Horizontal;
    //public float moveX;
    //public float moveY;

    public float speedUpRate;

    public Transform trans;
    public Rigidbody2D rb;
    public TopRotate_Player1 rotateScr;
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        //moveX = Input.GetAxis("Horizontal");
        //moveY = Input.GetAxis("Vertical");

        Movement();
    }
    // Update is called once per frame
    void Update()
    {
        SpeedUp();     
    }

    void Movement()
    {
        if(rotateScr.rotateSpeed!=0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (currentMoveSpeedHorizontal > -maxMoveSpeed_Horizontal)
                {
                    currentMoveSpeedHorizontal = Mathf.Lerp(currentMoveSpeedHorizontal, -maxMoveSpeed_Horizontal, Time.deltaTime);
                }
                if (currentMoveSpeedHorizontal > 0)
                {
                    transform.Translate(0, 0, 0);
                }
                else
                {
                    transform.Translate(currentMoveSpeedHorizontal, 0, 0);
                }
               
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                if (currentMoveSpeedHorizontal < maxMoveSpeed_Horizontal)
                {
                    currentMoveSpeedHorizontal = Mathf.Lerp(currentMoveSpeedHorizontal, maxMoveSpeed_Horizontal, Time.deltaTime);
                }
                if (currentMoveSpeedHorizontal < 0)
                {
                    transform.Translate(0, 0, 0);
                }
                else
                {
                    transform.Translate(currentMoveSpeedHorizontal, 0 , 0);
                }
                
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (currentMoveSpeed < maxMoveSpeed_Vertical)
                {
                    currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, maxMoveSpeed_Vertical, Time.deltaTime);
                }
                if(currentMoveSpeed<0)
                {
                    transform.Translate(0, 0, 0);
                }
                else
                {
                    transform.Translate(0, currentMoveSpeed, 0);
                }
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (currentMoveSpeed > -maxMoveSpeed_Vertical)
                {
                    currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, -maxMoveSpeed_Vertical, Time.deltaTime);
                }
                if (currentMoveSpeed > 0)
                {
                    transform.Translate(0, 0, 0);
                }
                else
                {
                    transform.Translate(0, currentMoveSpeed, 0);
                }  
            }
            if(!Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
            {
                currentMoveSpeed = Mathf.Lerp(currentMoveSpeed,0, Time.deltaTime);
                transform.Translate(0, currentMoveSpeed, 0);
            }
            if (!Input.GetKeyDown(KeyCode.A)&& !Input.GetKeyDown(KeyCode.D))
            {
                currentMoveSpeedHorizontal = Mathf.Lerp(currentMoveSpeedHorizontal, 0, Time.deltaTime);
                transform.Translate(0, currentMoveSpeedHorizontal, 0);
            }
        }
        
    }

    void SpeedUp()
    {
        if (!Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rotateScr.rotateSpeed += speedUpRate;
            }
        }
    }
}
