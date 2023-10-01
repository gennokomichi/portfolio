using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System;
using UnityEngine.SceneManagement;

public class GameResultController : MonoBehaviour
{
    public Text resultText;
    public int remainingLives = 16; //今回は16人いるという設定
    public int winPoint = 18;       //必要な勝利数
    public int loserPoint = 16;     //必要な敗北数

    public int winCount = 0;        //成功の回数
    public int loseCount = 0;       //失敗の回数
    public Button backButton;　　　 //タイトルへ

    public AudioClip winSound;　　　
    public AudioClip loseSound;　　
    public AudioSource audioSource;

    public BGMController bgmController;　// BGMを管理するスクリプト

   


    public enum GameState　　// ゲームの状態を表す列挙型　　　　
    {
        Playing,
        GameOver,
        GameClear
    }

    public GameState gameState = GameState.Playing;　　// 現在のゲーム状態


    // 勝利時の処理
    public void ShowWin()
    {
        // ゲーム状態がPlayingでないなら何もしない
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
            resultText.text = "ゲームクリア！\n" + remainingLives + "人、生き残った";
            bgmController.PlayVictoryBGM();
            gameState = GameState.GameClear;  //gameStateを変えて、パネルを押しても更新しないようにする
            backButton.gameObject.SetActive(true); // ボタンを表示
        }
    }



    // 敗北時の処理
    public void ShowLose()
    {
        // ゲーム状態がPlayingでないなら何もしない
        if (gameState != GameState.Playing)　 
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
            resultText.text = "ゲームオーバー";
            bgmController.PlayDefeatBGM();
            gameState = GameState.GameOver;  //gameStateを変えて、パネルを押しても更新しないようにする
            backButton.gameObject.SetActive(true); // ボタンを表示
        }
       
    }

   



// TitleSceneに戻る
        public void BackToTitle()
    {
        backButton.gameObject.SetActive(false); // ボタンを非表示にする
                                                // "TitleScene"はあなたのタイトルシーンの名前に変更してください
        SceneManager.LoadScene("TitleScene");
    }



    // ランダムな結果を生成
    public void RandomResult()
    {
        // ゲーム状態がPlayingでないなら何もしない
        if (gameState != GameState.Playing)
        {
            return;
        }

        
        int randomValue = UnityEngine.Random.Range(0, 2);　　//２分の１の確率をランダムで表す

        if (randomValue == 0)
        {
            ShowWin();
        }
        else
        {
            ShowLose();
        }
    }

    // 結果をテキストに更新
    private void UpdateResultText()
    {
        resultText.text = "残機: " + remainingLives + "\n勝ち: " + winCount + "\n負け: " + loseCount;
    }

    // ゲームをリセット
    public void ResetGame()
    {
       

        remainingLives = 16;
           
        winCount = 0;
        loseCount = 0;

        UpdateResultText();
        bgmController.PlayMainBGM();
        gameState = GameState.Playing;
    }

    // 音を再生
    void PlaySound(AudioClip clip)　　　
    {
        audioSource.clip = clip;　// 再生する音を設定
        audioSource.Play();　　// 音を再生
    }
}

