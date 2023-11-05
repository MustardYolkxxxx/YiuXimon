using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeRotate : MonoBehaviour
{
    public float speed = 100f; // 每秒旋转的度数

    void Update()
    {

        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
