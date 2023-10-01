using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System;
using UnityEngine.SceneManagement;

public class GameResultController : MonoBehaviour
{
    public Text resultText;
    public int remainingLives = 16; //�����16�l����Ƃ����ݒ�
    public int winPoint = 18;       //�K�v�ȏ�����
    public int loserPoint = 16;     //�K�v�Ȕs�k��

    public int winCount = 0;        //�����̉�
    public int loseCount = 0;       //���s�̉�
    public Button backButton;�@�@�@ //�^�C�g����

    public AudioClip winSound;�@�@�@
    public AudioClip loseSound;�@�@
    public AudioSource audioSource;

    public BGMController bgmController;�@// BGM���Ǘ�����X�N���v�g

   


    public enum GameState�@�@// �Q�[���̏�Ԃ�\���񋓌^�@�@�@�@
    {
        Playing,
        GameOver,
        GameClear
    }

    public GameState gameState = GameState.Playing;�@�@// ���݂̃Q�[�����


    // �������̏���
    public void ShowWin()
    {
        // �Q�[����Ԃ�Playing�łȂ��Ȃ牽�����Ȃ�
        if (gameState != GameState.Playing) 
        {
            return;
        } 

        if (winCount < winPoint)               
        {
            winCount++;
            UpdateResultText();
            PlaySound(winSound);
        }

        if (winCount >= winPoint)
        {
            resultText.text = "�Q�[���N���A�I\n" + remainingLives + "�l�A�����c����";
            bgmController.PlayVictoryBGM();
            gameState = GameState.GameClear;  //gameState��ς��āA�p�l���������Ă��X�V���Ȃ��悤�ɂ���
            backButton.gameObject.SetActive(true); // �{�^����\��
        }
    }



    // �s�k���̏���
    public void ShowLose()
    {
        // �Q�[����Ԃ�Playing�łȂ��Ȃ牽�����Ȃ�
        if (gameState != GameState.Playing)�@ 
        {
            return;
        }

        if (remainingLives > 0 && loseCount < loserPoint)
        {
            remainingLives--;
            loseCount++;
            UpdateResultText();
            PlaySound(loseSound);

        } 

        if (loseCount >= loserPoint)
        {
            resultText.text = "�Q�[���I�[�o�[";
            bgmController.PlayDefeatBGM();
            gameState = GameState.GameOver;  //gameState��ς��āA�p�l���������Ă��X�V���Ȃ��悤�ɂ���
            backButton.gameObject.SetActive(true); // �{�^����\��
        }
       
    }

   



// TitleScene�ɖ߂�
        public void BackToTitle()
    {
        backButton.gameObject.SetActive(false); // �{�^�����\���ɂ���
                                                // "TitleScene"�͂��Ȃ��̃^�C�g���V�[���̖��O�ɕύX���Ă�������
        SceneManager.LoadScene("TitleScene");
    }



    // �����_���Ȍ��ʂ𐶐�
    public void RandomResult()
    {
        // �Q�[����Ԃ�Playing�łȂ��Ȃ牽�����Ȃ�
        if (gameState != GameState.Playing)
        {
            return;
        }

        
        int randomValue = UnityEngine.Random.Range(0, 2);�@�@//�Q���̂P�̊m���������_���ŕ\��

        if (randomValue == 0)
        {
            ShowWin();
        }
        else
        {
            ShowLose();
        }
    }

    // ���ʂ��e�L�X�g�ɍX�V
    private void UpdateResultText()
    {
        resultText.text = "�c�@: " + remainingLives + "\n����: " + winCount + "\n����: " + loseCount;
    }

    // �Q�[�������Z�b�g
    public void ResetGame()
    {
       

        remainingLives = 16;
           
        winCount = 0;
        loseCount = 0;

        UpdateResultText();
        bgmController.PlayMainBGM();
        gameState = GameState.Playing;
    }

    // �����Đ�
    void PlaySound(AudioClip clip)�@�@�@
    {
        audioSource.clip = clip;�@// �Đ����鉹��ݒ�
        audioSource.Play();�@�@// �����Đ�
    }
}

