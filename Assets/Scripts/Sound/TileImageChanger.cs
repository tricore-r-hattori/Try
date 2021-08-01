﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// タイルの種類
/// </summary>
public enum TileType
{
    Tile,
    RareTile,
}

/// <summary>
/// 瓦の画像を変換するためのクラス
/// </summary>
public class TileImageChanger : MonoBehaviour
{
    // 瓦の画像
    [SerializeField]
    Image tileImage = default;

    // 瓦
    [SerializeField]
    RectTransform tileTransform = default;

    // 瓦の画像を変える地点
    [SerializeField]
    RectTransform tileSpriteChangePoint = default;

    // 割れていない瓦の画像のリスト
    [SerializeField]
    List<Sprite> tileSpriteList = default;

    // 割れている瓦の画像のリスト
    [SerializeField]
    List<Sprite> breakTileSpriteList = default;

    // 確率判定でレア瓦の画像を変更するか確認
    [SerializeField]
    RareTileChangeChecker rareTileChangeChecker = default;

    // 瓦が割れたか確認するフラグ
    bool isBreakTile = false;

    /// <summary>
    /// 割った瓦をカウント
    /// </summary>
    public event Action CountingBrokenTile = default;

    public event Action<AudioClip> B = default;

    [SerializeField]
    AudioClip audioClip = default;

    /// <summary>
    /// 開始処理
    /// </summary>
    void Start()
    {
        isBreakTile = false;

        // レア瓦の画像を変更できる状態ならレア瓦の画像に設定
        if (rareTileChangeChecker.IsRareTileChange)
        {
            // レア瓦の画像に設定
            tileImage.sprite = tileSpriteList[(int)TileType.RareTile];
        }
        // レア瓦の画像を変更できない状態なら通常の瓦の画像に設定
        else
        {
            // 通常の瓦の画像に設定
            tileImage.sprite = tileSpriteList[(int)TileType.Tile];
        }
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        // レア瓦に変更できる状態
        if (rareTileChangeChecker.IsRareTileChange)
        {
            // 画像を変える地点より低い位置にいた時かつ割れているレア瓦の状態の時に画像を変換
            if (tileTransform.position.y < tileSpriteChangePoint.position.y && isBreakTile)
            {
                // 割れていないレア瓦に変換
                tileImage.sprite = tileSpriteList[(int)TileType.RareTile];
                isBreakTile = false;
            }

            // 画像を変える地点より高い位置にいた時かつ割れていないレア瓦の状態の時に画像を変換
            if (tileTransform.position.y > tileSpriteChangePoint.position.y && !isBreakTile)
            {
                // 割れているレア瓦に変換
                tileImage.sprite = breakTileSpriteList[(int)TileType.RareTile];
                isBreakTile = true;

                // 画像が割れている瓦に変更されたら割った瓦をカウント
                CountingBrokenTile();

                B(audioClip);
            }
        }
        // レア瓦に変更できない状態
        else
        {
            // 画像を変える地点より低い位置にいた時かつ割れている瓦の状態の時に画像を変換
            if (tileTransform.position.y < tileSpriteChangePoint.position.y && isBreakTile)
            {
                // 割れていない瓦に変換
                tileImage.sprite = tileSpriteList[(int)TileType.Tile];
                isBreakTile = false;
            }

            // 画像を変える地点より高い位置にいた時かつ割れていない瓦の状態の時に画像を変換
            if (tileTransform.position.y > tileSpriteChangePoint.position.y && !isBreakTile)
            {
                // 割れている瓦に変換
                tileImage.sprite = breakTileSpriteList[(int)TileType.Tile];
                isBreakTile = true;
                
                // 画像が割れている瓦に変更されたら割った瓦をカウント
                CountingBrokenTile();

                B(audioClip);
            }
        }
    }
}
