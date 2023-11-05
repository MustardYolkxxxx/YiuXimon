using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameObject createPos1;
    public GameObject createPos2;

    public CameraZoom camaraScr;
    public CenterObjectMove centerObjectScr;

    public TopDictionary topDicScr;

    public UI_WeightChoose1 weightChoose1Scr;
    public UI_WeightChoose2 weightChoose2Scr;

    public UI_BladeChoose1 bladeChoose1Scr;
    public UI_BladeChoose2 bladeChoose2Scr;

    public float weight1;
    public float weight2;

    public float bladeMaxSpeed1;
    public float bladeMaxSpeed2;

    public float blade1SpeedUpRate;
    public float blade2SpeedUpRate;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlayer1()
    {
        Instantiate(player1,createPos1.transform.position,Quaternion.identity);
        camaraScr.FindPlayer(1);
        centerObjectScr.FindPlayer(1);
    }

    public void CreatePlayer2()
    {
        Instantiate(player2, createPos2.transform.position, Quaternion.identity);
        camaraScr.FindPlayer(2);
        centerObjectScr.FindPlayer(2);
    }

    public void ChangeWeight(int player, int index)
    {
        if(player==1)
        {
            weight1 = topDicScr.WeightDic[index].weight;
        }
        if (player == 2)
        {
            weight2 = topDicScr.WeightDic[index].weight;
        }
    }

    public void ChangeMaxSpeed(int player,int index)
    {
        if (player == 1)
        {
            bladeMaxSpeed1 = topDicScr.BladeDic[index].maxSpeed;
        }
        if (player == 2)
        {
            bladeMaxSpeed2 = topDicScr.BladeDic[index].maxSpeed;
        }
    }

    public void ChangeSpeedUpRate(int player,int index)
    {
        if (player == 1)
        {
            blade1SpeedUpRate = topDicScr.BladeDic[index].speedUpRate;
        }
        if (player == 2)
        {
            blade2SpeedUpRate = topDicScr.BladeDic[index].speedUpRate;
        }
    }
}
