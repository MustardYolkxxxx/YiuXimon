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
        camaraScr.FindPlayer();
        centerObjectScr.FindPlayer();
    }

    public void CreatePlayer2()
    {
        Instantiate(player2, createPos2.transform.position, Quaternion.identity);
        camaraScr.FindPlayer();
        centerObjectScr.FindPlayer();
    }
}
