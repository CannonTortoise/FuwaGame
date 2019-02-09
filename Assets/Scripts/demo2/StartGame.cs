using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // 开始按钮
    public Button StartBtn;
    void Start()
    {
        StartBtn.onClick.AddListener(delegate() { this.start_game("demo3"); });
    }

    // 开始游戏
    public void start_game(string level)
    {
        SceneManager.LoadScene(level);
    }
}
