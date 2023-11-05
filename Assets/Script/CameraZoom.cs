using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public TopMove_Player1 player1Scr;
    public TopMove_Player2 player2Scr;

    public Vector3 distance;

    public float controlDis;
    // Start is called before the first frame update
    void Start()
    {
        player1Scr = FindObjectOfType<TopMove_Player1>();
        player2Scr = FindObjectOfType<TopMove_Player2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Scr!= null&&player2Scr!=null) 
        {
            distance = player1Scr.transform.position - player2Scr.transform.position;
            virtualCamera.m_Lens.OrthographicSize = (distance.magnitude / 2) + controlDis;
        }
        
    }

    public void FindPlayer()
    {
        if(player1Scr== null)
        {
            player1Scr = FindObjectOfType<TopMove_Player1>();
        }
        if (player2Scr == null)
        {
            player2Scr = FindObjectOfType<TopMove_Player2>();
        }

    
    }
}
