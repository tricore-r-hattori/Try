using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音を管理する
/// </summary>
public class SoundManager : MonoBehaviour
{
    // 瓦の画像を変えるクラス
    [SerializeField]
    List<TileImageChanger> tileImageChanger = default;

    [SerializeField]
    OnEnableCheck resultObject = default;

    [SerializeField]
    AudioSource audioSource = default;

    void Start()
    {
        for (int i = 0; i < tileImageChanger.Count; i++)
        {
            tileImageChanger[i].A += PlaySound;
        }

        resultObject.Sound += PlaySound;
    }

    void OnApplicationQuit()
    {
        for (int i = 0; i < tileImageChanger.Count; i++)
        {
            tileImageChanger[i].A -= PlaySound;
        }
    }

    void PlaySound(AudioClip _audioClip)
    {
        audioSource.PlayOneShot(_audioClip);
    }
}
