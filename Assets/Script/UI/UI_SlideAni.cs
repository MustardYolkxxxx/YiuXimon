using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlideAni : MonoBehaviour
{

    public Transform trans;
    public CanvasGroup canvasGroup;

    public float transparentTime =0.1f;
    public float moveDistanceX=300;
    public float moveTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlideRight()
    {
        canvasGroup.alpha = 0;
        canvasGroup.LeanAlpha(1, transparentTime);
        trans.localPosition = new Vector3(moveDistanceX, 0,0);
        trans.LeanMoveLocalX(0, moveTime).setEaseOutQuad();

    }

    public void SlideLeft()
    {
        canvasGroup.alpha = 0;
        canvasGroup.LeanAlpha(1, transparentTime);
        trans.localPosition = new Vector3(-moveDistanceX, 0, 0);
        trans.LeanMoveLocalX(0, moveTime).setEaseOutQuad();
    }

    public void SlideLeftDisappear()
    {
        canvasGroup.alpha = 1;
        canvasGroup.LeanAlpha(0, transparentTime);
        trans.localPosition = new Vector3(0, 0, 0);
        trans.LeanMoveLocalX(-moveDistanceX, moveTime).setEaseOutQuad();
    }
    public void SlideRightDisappear()
    {
        canvasGroup.alpha = 1;
        canvasGroup.LeanAlpha(0, transparentTime);
        trans.localPosition = new Vector3(0, 0, 0);
        trans.LeanMoveLocalX(moveDistanceX, moveTime).setEaseOutQuad();
    }
}
