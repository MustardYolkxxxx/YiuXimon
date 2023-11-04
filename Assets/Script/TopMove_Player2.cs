using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMove_Player2 : MonoBehaviour
{
    public float moveSpeed;
    //public float moveX;
    //public float moveY;

    public float speedUpRate;

    public Transform trans;
    public Rigidbody2D rb;
    public TopRotate_Player2 rotateScr;
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-moveSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(moveSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, moveSpeed, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -moveSpeed, 0);
            }
        }
        
    }

    void SpeedUp()
    {
        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                rotateScr.rotateSpeed += speedUpRate;
            }
        }
    }
}
