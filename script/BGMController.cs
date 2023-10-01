using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource�R���|�[�l���g
    public AudioClip mainBGM;  // ���C����BGM
    public AudioClip victoryBGM;  // �������ɍĐ�����BGM
    public AudioClip defeatBGM;   // �s�k���ɍĐ�����BGM

    // ���C����BGM���Đ�
    public void PlayMainBGM()
    {
        PlayBGM(mainBGM);
    }

    // ��������BGM���Đ�
    public void PlayVictoryBGM()
    {
        PlayBGM(victoryBGM);
    }

    // �s�k����BGM���Đ�
    public void PlayDefeatBGM()
    {
        PlayBGM(defeatBGM);
    }

    // �w�肳�ꂽBGM���Đ�����
    private void PlayBGM(AudioClip clip)
    {
        audioSource.clip = clip; // �Đ�����BGM��ݒ�
        audioSource.Play(); // BGM���Đ�
    }

    // BGM�̍Đ����~
    public void StopBGM()
    {
        audioSource.Stop(); // BGM���~
    }

   

}
