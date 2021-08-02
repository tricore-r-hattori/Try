using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ScoreType
{
    NormalScore,
    PastScore,
    NormalTileHighScore,
    RainbowTileHighScore,
}

/// <summary>
/// スコア表示
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField]
    CountBrokenTile countBrokenTile = default;

    [SerializeField]
    List<TextMeshProUGUI> ScoreText = default;

    void OnEnable()
    {
        ScoreText[(int)ScoreType.NormalScore].text = countBrokenTile.CountBrokenTileString;
        ScoreText[(int)ScoreType.PastScore].text = countBrokenTile.CountBrokenTileString;
        ScoreText[(int)ScoreType.NormalTileHighScore].text = countBrokenTile.CountBrokenTileString;
        ScoreText[(int)ScoreType.RainbowTileHighScore].text = countBrokenTile.CountBrokenTileString;
    }
}
