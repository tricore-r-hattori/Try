﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リザルトへのシーン遷移
/// </summary>
public class ResultTransition : MonoBehaviour
{
    // 瓦のスクロール
    [SerializeField]
    TileScroller tileScroller = default;

    // シーケンスのアニメーター
    [SerializeField]
    Animator sequenceAnimator = default;

    // 待つ時間
    [SerializeField]
    int waitFrame = 120;

    // 待っている時間をカウント
    int waitFrameCount = 0;

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        // スクロールがストップしたらリザルトへ遷移する
        if (tileScroller.IsScrollStop)
        {
            waitFrameCount++;

            // シーン遷移する時に何秒か待つ
            if (waitFrameCount > waitFrame)
            {
                waitFrameCount = 0;
                sequenceAnimator.SetTrigger("isResultScene");
            }
        }
    }
}
