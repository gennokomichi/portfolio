using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explainController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("main");  // "GameScene"は遷移したいシーンの名前
    }
}
