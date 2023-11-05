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

    public int sprite1;
    public int sprite2;

    public int avatarSprite1;
    public int avatarSprite2;

    public float weight1;
    public float weight2;

    public float weightForce1;
    public float weightForce2;

    public float bladeMaxSpeed1;
    public float bladeMaxSpeed2;

    public float blade1SpeedUpRate;
    public float blade2SpeedUpRate;

    public float bladeSpeedDownRate1;
    public float bladeSpeedDownRate2;

    public float player1Score;
    public float player2Score;
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

    public void ChangeAvatar(int player, int index)
    {
        if (player == 1)
        {
            avatarSprite1 = index;
        }
        if (player == 2)
        {
            avatarSprite2 = index;
        }
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

    public void ChangeWeightForce(int player, int index)
    {
        if (player == 1)
        {
            weightForce1 = topDicScr.WeightDic[index].weightForce;
        }
        if (player == 2)
        {
            weightForce2 = topDicScr.WeightDic[index].weightForce;
        }
    }

    public void ChangeMaxSpeed(int player,int index)
    {
        if (player == 1)
        {
            sprite1 = index;
            bladeMaxSpeed1 = topDicScr.BladeDic[index].maxSpeed;
        }
        if (player == 2)
        {
            sprite2= index;
            bladeMaxSpeed2 = topDicScr.BladeDic[index].maxSpeed;
        }
    }

    public void ChangeSpeedDownRate(int player, int index)
    {
        if (player == 1)
        {
            bladeSpeedDownRate1 = topDicScr.BladeDic[index].speedDownRate;
        }
        if (player == 2)
        {
            bladeSpeedDownRate2 = topDicScr.BladeDic[index].speedDownRate;
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
