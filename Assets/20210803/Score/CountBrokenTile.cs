﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 割った瓦をカウント
/// </summary>
public class CountBrokenTile : MonoBehaviour
{
    // 割った瓦をカウントするオブジェクトのTextMeshPro
    [SerializeField]
    TextMeshProUGUI countText = default;

    // 瓦の画像を変換するスクリプトのリスト
    [SerializeField]
    List<TileImageChanger> tileImageChanger = default;

    // 確率判定でレア瓦の画像を変更するか確認
    [SerializeField]
    RareTileChangeChecker rareTileChangeChecker = default;

    // 割った瓦をカウント
    public int BrokenTilesCount { get; private set; } = 0;
    // 割ったレア瓦をカウント
    public int BreakRareTilesCount { get; private set; } = 0;

    // カウントする瓦のテキストの文字列
    string countBrokenTileString = default;

    // カウントするレア瓦のテキストの文字列
    string countBreakRareTileString = default;

    /// <summary>
    /// アクティブ化した時に1回だけ処理を行う
    /// </summary>
    void OnEnable()
    {
        // カウント初期化
        BrokenTilesCount = 0;
        BreakRareTilesCount = 0;

        // 全ての瓦に関数を登録
        for (int i = 0; i < tileImageChanger.Count; i++)
        {
            tileImageChanger[i].Init(CountBrokenTileText);
        }
    }

    /// <summary>
    /// 割った瓦のカウントした値をテキストで表示
    /// </summary>
    void CountBrokenTileText()
    {
        if (rareTileChangeChecker.IsRareTileChange)
        {
            BreakRareTilesCount++;
            countBreakRareTileString = BreakRareTilesCount + "枚";

            countText.text = countBreakRareTileString;
        }
        else
        {
            BrokenTilesCount++;
            countBrokenTileString = BrokenTilesCount + "枚";

            countText.text = countBrokenTileString;
        }
    }
}
