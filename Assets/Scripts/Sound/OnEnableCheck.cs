using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnEnableCheck : MonoBehaviour
{
    public event Action<AudioClip> Sound;

    [SerializeField]
    AudioClip audioClip = default;

    void OnEnable()
    {
        Sound(audioClip);
    }
}
