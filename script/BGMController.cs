using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource audioSource; // AudioSourceコンポーネント
    public AudioClip mainBGM;  // メインのBGM
    public AudioClip victoryBGM;  // 勝利時に再生するBGM
    public AudioClip defeatBGM;   // 敗北時に再生するBGM

    // メインのBGMを再生
    public void PlayMainBGM()
    {
        PlayBGM(mainBGM);
    }

    // 勝利時のBGMを再生
    public void PlayVictoryBGM()
    {
        PlayBGM(victoryBGM);
    }

    // 敗北時のBGMを再生
    public void PlayDefeatBGM()
    {
        PlayBGM(defeatBGM);
    }

    // 指定されたBGMを再生する
    private void PlayBGM(AudioClip clip)
    {
        audioSource.clip = clip; // 再生するBGMを設定
        audioSource.Play(); // BGMを再生
    }

    // BGMの再生を停止
    public void StopBGM()
    {
        audioSource.Stop(); // BGMを停止
    }

   

}
