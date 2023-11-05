using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotate_Player1 : MonoBehaviour
{
    public float rotateSpeed;

    public float rotateSpeedDown;
    public Transform trans;

    public float originMaxRotateSpeed;
    public float maxRotateSpeed;

    public TopDictionary topDicScr;

    public UI_BladeChoose1 bladeChooseScr;
    // Start is called before the first frame update
    void Start()
    {
        maxRotateSpeed = originMaxRotateSpeed;
        trans = gameObject.GetComponent<Transform>();
        topDicScr = FindObjectOfType<TopDictionary>();
        bladeChooseScr = FindObjectOfType<UI_BladeChoose1>();
    }

    private void FixedUpdate()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        trans.rotation*= Quaternion.Euler(0,0, rotateSpeed);
        rotateSpeed -= rotateSpeedDown*Time.deltaTime;
        maxRotateSpeed = originMaxRotateSpeed + topDicScr.BladeDic[bladeChooseScr.bladeIndex].maxSpeed;
        
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
}
