using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("explainsence");  // "GameScene"�͑J�ڂ������V�[���̖��O
    }
}
