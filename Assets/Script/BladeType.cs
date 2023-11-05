using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeType
{

    public string bladeName;
    public int id;
    public float maxSpeed;
    public float speedUpRate;

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
    public BladeType(int id, string name, float speed, float speedUpRate)
    {
        this.id = id;
        this.bladeName = name;
        this.maxSpeed = speed;
        this.speedUpRate = speedUpRate;
    }
    // Start is called before the first frame update
}
