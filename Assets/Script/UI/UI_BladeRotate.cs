using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BladeRotate : MonoBehaviour
{

    public float rotateSpeed;

    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans= GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        trans.rotation *= Quaternion.Euler(0, 0, rotateSpeed);
    }
}
