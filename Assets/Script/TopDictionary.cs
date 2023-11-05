using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDictionary : MonoBehaviour
{

    public Dictionary<int,BladeType> BladeDic= new Dictionary<int,BladeType>();

    public Dictionary<int, WeightType> WeightDic = new Dictionary<int, WeightType>();
    // Start is called before the first frame update
    void Start()
    {
        BladeType b0= new BladeType(0,"FishBones",1,0.2f,0.5f);
        BladeType b1 = new BladeType(1, "Honor", 0.5f,0.3f,0.5f);
        BladeType b2 = new BladeType(2, "Rose", 0.2f,0.4f, 0.5f);
        BladeType b3 = new BladeType(3, "Doctor", 0.2f, 0.4f, 0.5f);
        BladeType b4 = new BladeType(4, "FancyEgg", 0.2f, 0.4f, 0.5f);
        BladeType b5 = new BladeType(5, "FireWing", 0.2f, 0.4f, 0.5f);
        BladeType b6 = new BladeType(6, "Spider", 0.2f, 0.4f, 0.5f);
        BladeType b7 = new BladeType(7, "WingStorm", 0.2f, 0.4f, 0.5f);

        BladeDic.Add(b0.id,b0);
        BladeDic.Add(b1.id, b1);
        BladeDic.Add(b2.id, b2);
        BladeDic.Add(b3.id, b3);
        BladeDic.Add(b4.id, b4);
        BladeDic.Add(b5.id, b5);
        BladeDic.Add(b6.id, b6);
        BladeDic.Add(b7.id, b7);

        WeightType w0 = new WeightType(0, "C-Weight", 1 , 5);
        WeightType w1 = new WeightType(1, "DC-Weight", 2, 5);
        WeightType w2 = new WeightType(2, "TC-Weight", 3, 5);

        WeightDic.Add(w0.id,w0);
        WeightDic.Add(w1.id, w1);
        WeightDic.Add(w2.id, w2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
