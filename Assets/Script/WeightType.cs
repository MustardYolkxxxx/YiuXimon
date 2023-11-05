using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightType
{

    public string weightName;
    public int id;
    public float weight;
    public float weightForce;
    
    public WeightType()
    {

    }
    public WeightType(int id)
    {
        this.id = id;
    }

    public WeightType(int id,string weightName)
    {
        this.id = id;
        this.weightName = weightName;
    }

    public WeightType(int id, string weightName,float weight)
    {
        this.id = id;
        this.weightName = weightName;
        this.weight = weight;
    }

    public WeightType(int id, string weightName, float weight,float weightForce)
    {
        this.id = id;
        this.weightName = weightName;
        this.weight = weight;
        this.weightForce = weightForce;
    }
}
