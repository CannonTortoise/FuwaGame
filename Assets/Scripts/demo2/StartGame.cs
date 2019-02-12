﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
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
=======
public class StartGame : MonoBehaviour {

    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("highest score") || PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highest score"))
        {
            PlayerPrefs.SetString("highest name", PlayerPrefs.GetString("player name"));
            PlayerPrefs.SetInt("highest score", PlayerPrefs.GetInt("score"));
        }
        GameObject.Find("HighestScore").GetComponent<Text>().text = "Highest Score: \n" +
        PlayerPrefs.GetString("highest name") + " " + System.Convert.ToString(PlayerPrefs.GetInt("highest score"));
        PlayerPrefs.SetString("player name", null);
        PlayerPrefs.SetInt("score", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartLevel(string Level) {
        if (PlayerPrefs.GetString("player name") == null)
            PlayerPrefs.SetString("player name", "Turtle");
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(Level);
    }

    public void InputName(string Name) {
        PlayerPrefs.SetString("player name", Name);
    }

    public void Reset() {
        PlayerPrefs.SetInt("highest score", 0);
        PlayerPrefs.SetString("highest name", "Turtle");
        GameObject.Find("HighestScore").GetComponent<Text>().text = "Highest Score: \n" +
        PlayerPrefs.GetString("highest name") + " " + System.Convert.ToString(PlayerPrefs.GetInt("highest score"));
>>>>>>> 86179e8cbafc278c7424782e5471411d22ef9d15
    }
}
