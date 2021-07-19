using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    RectTransform imageTransform;

    [SerializeField]
    Sprite sprite;

    const float imageChangePoint = 320;

    void Update()
    {
        if (imageTransform.localPosition.y >= imageChangePoint)
        {
            image.sprite = sprite;
        }
    }
}