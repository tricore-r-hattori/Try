using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// スコア
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// スコアの種類
    /// </summary>
    public enum ScoreType
    {
        PastScore,
        TileHighScore,
        RareTileHighScore,
        NowScore,
        TitleName,
    }

    // 割った瓦をカウント
    [SerializeField]
    BreakTileCounter breakTileCounter = default;

    // スコアを表示するテキスト(TextMeshPro)
    [SerializeField]
    List<TextMeshProUGUI> scoreTextList = default;

    // 確率判定でレア瓦の画像を変更するか確認
    [SerializeField]
    RareTileChangeChecker rareTileChangeChecker = default;

    // 現在のスコアのリスト
    List<int> scoreList = new List<int> {0,0,0};

    // スコアデータリスト
    List<string> scoreDateNameList = new List<string> { "PastScoreData", "TileHighScoreData", "RareTileHighScoreData" };

    // 現在のスコアによる称号リスト
    List<string> nowScoreTitleList = new List<string> { "鬼", "竜", "神" };

    // 過去のスコアによる称号リスト
    List<string> pastScoreTitleList = new List<string> { "白帯の","黄帯の","黒帯の"};

    // カウントする瓦の単位の文字列
    const string breakTileCountUnitString = "枚";

    string nowScoreTitle = default;

    string pastScoreTitle = default;

    /// <summary>
    /// 起動処理
    /// </summary>
    void Awake()
    {
        // スコアデータを読み込み
        for (int i = 0; i < scoreDateNameList.Count; i++)
        {
            scoreList[i] = PlayerPrefs.GetInt(scoreDateNameList[i], 0);
        }
    }

    /// <summary>
    /// アクティブ化した時に1回だけ処理を行う
    /// </summary>
    void OnEnable()
    {
        // レアの瓦の状態でスコア比較処理へ
        if (rareTileChangeChecker.IsRareTileChange)
        {
            // 現在のスコアと過去のハイスコアを比べて、現在のスコアの値の方が大きかったらハイスコア更新
            if (breakTileCounter.BreakTilesCount >= scoreList[(int)ScoreType.RareTileHighScore])
            {
                scoreList[(int)ScoreType.RareTileHighScore] = breakTileCounter.BreakTilesCount;
            }
        }
        // 通常の瓦の状態でスコア比較処理へ
        else
        {
            // 現在のスコアと過去のハイスコアを比べて、現在のスコアの値の方が大きかったらハイスコア更新
            if (breakTileCounter.BreakTilesCount >= scoreList[(int)ScoreType.TileHighScore])
            {
                scoreList[(int)ScoreType.TileHighScore] = breakTileCounter.BreakTilesCount;
            }
        }

        // 今までプレイしてきたスコアの合計を計算
        scoreList[(int)ScoreType.PastScore] += breakTileCounter.BreakTilesCount;

        // 今割った瓦のカウントをテキストで表示
        scoreTextList[(int)ScoreType.NowScore].text = breakTileCounter.BreakTilesCount + breakTileCountUnitString;

        // スコアデータを表示して保存する
        for (int i = 0; i < scoreDateNameList.Count; i++)
        {
            scoreTextList[i].text = scoreList[i] + breakTileCountUnitString;
            PlayerPrefs.SetInt(scoreDateNameList[i], scoreList[i]);
        }

        if (breakTileCounter.BreakTilesCount >= 200)
        {
            nowScoreTitle = nowScoreTitleList[2];
        }

        if (breakTileCounter.BreakTilesCount >= 100 && breakTileCounter.BreakTilesCount < 200)
        {
            nowScoreTitle = nowScoreTitleList[1];
        }

        if (breakTileCounter.BreakTilesCount < 100)
        {
            nowScoreTitle = nowScoreTitleList[0];
        }

        if (scoreList[(int)ScoreType.PastScore] >= 2000)
        {
            pastScoreTitle = pastScoreTitleList[2];
        }

        if (scoreList[(int)ScoreType.PastScore] >= 1000 && scoreList[(int)ScoreType.PastScore] < 2000)
        {
            pastScoreTitle = pastScoreTitleList[1];
        }

        if (scoreList[(int)ScoreType.PastScore] < 1000)
        {
            pastScoreTitle = pastScoreTitleList[0];
        }

        scoreTextList[(int)ScoreType.TitleName].text = pastScoreTitle + nowScoreTitle;

        PlayerPrefs.Save();
    }
}
