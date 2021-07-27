using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountingBrokenTilesText : MonoBehaviour
{
    [SerializeField]
    Text Count = default;

    [SerializeField]
    List<TileImageChanger> tile = new List<TileImageChanger>();

    int brokenTilesCount = 0;

    void OnEnable()
    {
        brokenTilesCount = 0;

        for (int i = 0; i < tile.Count; i++)
        {
            tile[i].A += Method;
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < tile.Count; i++)
        {
            tile[i].A -= Method;
        }
    }

    public void Method()
    {
        brokenTilesCount++;

        Count.text = brokenTilesCount.ToString();

        Debug.Log(brokenTilesCount);
    }
}
