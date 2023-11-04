using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMove_Player2 : MonoBehaviour
{
    public float currentMoveSpeed;
    public float currentMoveSpeedHorizontal;

    public float maxMoveSpeed;
    public float maxMoveSpeed_Vertical;
    public float maxMoveSpeed_Horizontal;
    //public float moveX;
    //public float moveY;
    public float controlTime;
    public float moveSpeedControl;
    public float speedUpRate;

    public Transform trans;
    public Rigidbody2D rb;
    public TopRotate_Player2 rotateScr;
    public TopCollide_Player2 collideScr;

    public enum TopMoveState
    {
        idle,
        move,
    }

    public TopMoveState currentMoveState;
    // Start is called before the first frame update
    void Start()
    {
        maxMoveSpeed_Vertical = maxMoveSpeed;
        maxMoveSpeed_Horizontal = maxMoveSpeed;
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
        if (currentMoveState == TopMoveState.idle)
        {
            SpeedUp();
        }

        if (currentMoveState == TopMoveState.move)
        {
            SpeedUp();
            CheckMoveSpeed();
            TopStop();
        }
        if (rotateScr.rotateSpeed >0.3)
        {
            currentMoveState = TopMoveState.move;
        }
    }

    void TopStop()
    {
        if (rotateScr.rotateSpeed <0.3)
        {
            StartCoroutine(TopStopIE());
        }
    }

    IEnumerator TopStopIE()
    {
        currentMoveState = TopMoveState.idle;
        yield return new WaitForSeconds(1);
        currentMoveSpeed = 0;
        currentMoveSpeedHorizontal = 0;

    }
    void CheckMoveSpeed()
    {
        if (maxMoveSpeed_Vertical > 0.2)
        {
            maxMoveSpeed_Vertical = 0.2f;
        }
        else
        {
            maxMoveSpeed_Vertical = maxMoveSpeed / rotateScr.rotateSpeed;
        }

        if (maxMoveSpeed_Horizontal > 0.2)
        {
            maxMoveSpeed_Horizontal = 0.2f;
        }
        else
        {
            maxMoveSpeed_Horizontal = maxMoveSpeed / rotateScr.rotateSpeed;
        }
    }


    void Movement()
    {
        if (!Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, 0, controlTime * Time.deltaTime * (1 / rotateScr.rotateSpeed));
            transform.Translate(0, currentMoveSpeed, 0);
        }
        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentMoveSpeedHorizontal = Mathf.Lerp(currentMoveSpeedHorizontal, 0, controlTime * Time.deltaTime * (1 / rotateScr.rotateSpeed));
            transform.Translate(currentMoveSpeedHorizontal, 0, 0);
        }
        if (currentMoveState == TopMoveState.move)
        {
            if (collideScr.currentCollideState != TopCollide_Player2.CollideState2.collideBack)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (currentMoveSpeedHorizontal > -maxMoveSpeed_Horizontal)
                    {
                        currentMoveSpeedHorizontal = Mathf.Lerp(currentMoveSpeedHorizontal, -maxMoveSpeed_Horizontal, moveSpeedControl * Time.deltaTime * (1 / rotateScr.rotateSpeed));
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

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (currentMoveSpeedHorizontal < maxMoveSpeed_Horizontal)
                    {
                        currentMoveSpeedHorizontal = Mathf.Lerp(currentMoveSpeedHorizontal, maxMoveSpeed_Horizontal, moveSpeedControl * Time.deltaTime * (1 / rotateScr.rotateSpeed));
                    }
                    if (currentMoveSpeedHorizontal < 0)
                    {
                        transform.Translate(0, 0, 0);
                    }
                    else
                    {
                        transform.Translate(currentMoveSpeedHorizontal, 0, 0);
                    }

                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (currentMoveSpeed < maxMoveSpeed_Vertical)
                    {
                        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, maxMoveSpeed_Vertical, moveSpeedControl * Time.deltaTime * (1 / rotateScr.rotateSpeed));
                    }
                    if (currentMoveSpeed < 0)
                    {
                        transform.Translate(0, 0, 0);
                    }
                    else
                    {
                        transform.Translate(0, currentMoveSpeed, 0);
                    }

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (currentMoveSpeed > -maxMoveSpeed_Vertical)
                    {
                        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, -maxMoveSpeed_Vertical, moveSpeedControl * Time.deltaTime * (1 / rotateScr.rotateSpeed));
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

            }
        }

    }

    void SpeedUp()
    {
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rotateScr.rotateSpeed += speedUpRate;
            }
        }
    }
}
