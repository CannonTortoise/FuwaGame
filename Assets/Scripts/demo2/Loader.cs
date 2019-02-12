﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour {
    //这个脚本用来控制每个场景中唯一只有一个GameManager
    public GameObject gamemanager;
    // Use this for initialization
    private void Awake()
    {
        if (ToolManager.Instance == null)
        {
            GameObject.Instantiate(gamemanager);
        }

        GameObject.Find("PlayerName").GetComponent<Text>().text = "Name: " + PlayerPrefs.GetString("player name");
        GameObject.Find("Score").GetComponent<Text>().text = "Score: 0";
    }
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}