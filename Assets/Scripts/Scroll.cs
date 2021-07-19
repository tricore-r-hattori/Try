using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Scroll : MonoBehaviour
{
    //スクロールスピード
    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    RectTransform image;

    Vector3 velocity = Vector3.zero;
    Vector3 MovePoint = Vector3.zero;

    const float scrollStartPoint = 320;
    const float scrollEndPoint = -320;

    void Start()
    {
        velocity = new Vector3(0, Time.deltaTime * speed);
        MovePoint = new Vector3(0.0f, scrollStartPoint, 0.0f);
    }

    void Update()
   {
        //下方向にスクロール
        image.localPosition -= velocity;
        
        if(image.localPosition.y <= scrollEndPoint)
        {
            image.localPosition = MovePoint;
        }
    }
}