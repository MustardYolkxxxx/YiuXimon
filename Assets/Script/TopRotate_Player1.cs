using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotate_Player1 : MonoBehaviour
{
    public float rotateSpeed;

    public float rotateSpeedDown;
    public Transform trans;


    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        trans.rotation*= Quaternion.Euler(0,0, rotateSpeed);
        rotateSpeed -= rotateSpeedDown*Time.deltaTime;
        CheckRotateSpeed();
    }

    void CheckRotateSpeed()
    {
        if(rotateSpeed < 0)
        {
            rotateSpeed= 0;
        }
    }
}
