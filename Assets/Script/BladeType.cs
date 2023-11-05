using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeType : MonoBehaviour
{

    public string bladeName;
    public int id;
    public float maxSpeed;

    public BladeType()
    {
        
    }
    public BladeType(int id)
    {
        this.id = id;
    }

    public BladeType(int id,string name)
    {
        this.id = id;
        this.bladeName = name;
    }

    public BladeType(int id, string name,float speed)
    {
        this.id = id;
        this.bladeName = name;
        this.maxSpeed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
