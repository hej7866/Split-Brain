using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleTon<AudioManager>
{
    AudioSource audioSource;
    AudioClip bgm;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Inspector에 지정된 기본 클립 가져오기
        bgm = audioSource.clip;
        StopBGM();
    }

    public void PlayBGM()
    {
        if (bgm != null)
        {
            audioSource.Play();
        }
    }

    // BGM 정지
    public void StopBGM()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // 일시정지
    public void PauseBGM()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    // 일시정지 후 다시 재생
    public void ResumeBGM()
    {
        audioSource.UnPause();
    }
}
