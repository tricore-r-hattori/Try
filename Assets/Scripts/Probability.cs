using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probability : MonoBehaviour
{
    [SerializeField]
    List<Image> myList = new List<Image>(); //Listの宣言
    Image rareTile;

    [SerializeField]
    Sprite sprite;

    void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    myList.Add(i); //Listに値を格納
        //}

        if (Probability_(10))
        {
            rareTile.sprite = sprite;
        }
    }

    /// <summary>
    /// 確率判定
    /// </summary>
    /// <param name="fPercent">確率 (0~100)</param>
    /// <returns>当選結果 [true]当選</returns>
    bool Probability_(float fPercent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if (fPercent == 100.0f && fProbabilityRate == fPercent)
        {
            return true;
        }
        else if (fProbabilityRate < fPercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
