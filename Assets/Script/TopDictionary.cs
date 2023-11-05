using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDictionary : MonoBehaviour
{

    public Dictionary<int,BladeType> BladeDic= new Dictionary<int,BladeType>();
    // Start is called before the first frame update
    void Start()
    {
        BladeType b0= new BladeType(0,"FishBones",1);
        BladeType b1 = new BladeType(1, "FishBones", 0.5f);
        BladeType b2 = new BladeType(2, "FishBones", 0.2f);

        BladeDic.Add(b0.id,b0);
        BladeDic.Add(b1.id, b1);
        BladeDic.Add(b2.id, b2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
