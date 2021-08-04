﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 割った瓦をカウント
/// </summary>
public class BreakTileCounter : MonoBehaviour
{
    // スクロールを操作するためのオブジェクトと当たったか確認する
    [SerializeField]
    ScrollControllObjectHitCheck scrollControllObjectHitCheck = default;

    // 割った瓦の値を表示するテキスト(TextMeshPro)
    [SerializeField]
    TextMeshProUGUI breakTileScoreText = default;

    // 瓦の画像を変換するスクリプトのリスト
    [SerializeField]
    List<TileImageChanger> tileImageChanger = default;

    // カウントする瓦の単位の文字列
    const string breakTileCountUnitString = "枚";

    /// <summary>
    /// 割った瓦をカウント
    /// </summary>
    public int BreakTilesCount { get; private set; } = 0;

    /// <summary>
    /// アクティブ化した時に1回だけ処理を行う
    /// </summary>
    void OnEnable()
    {
        // カウント初期化
        BreakTilesCount = 0;

        // 全ての瓦にカウント表示関数を登録
        for (int i = 0; i < tileImageChanger.Count; i++)
        {
            tileImageChanger[i].InitCountBreakTileAction(CountBreakTileText);
        }

        scrollControllObjectHitCheck.InitShowBreakTileScoreText(ShowBreakTileScoreText);
    }

    /// <summary>
    /// テキストを表示
    /// </summary>
    void ShowBreakTileScoreText()
    {
        breakTileScoreText.enabled = true;
    }

    /// <summary>
    /// 非アクティブ化した時に1回だけ処理を行う
    /// </summary>
    void OnDisable()
    {
        // テキストを非表示
        breakTileScoreText.enabled = false;
    }

    /// <summary>
    /// 割った瓦をカウント
    /// </summary>
    void CountBreakTileText()
    {
         BreakTilesCount++;
         breakTileScoreText.text = BreakTilesCount + breakTileCountUnitString;
    }
}
