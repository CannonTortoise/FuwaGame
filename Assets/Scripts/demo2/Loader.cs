using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour {
    //这个脚本用来控制每个场景中唯一只有一个GameManager
    public GameObject gamemanager;
    public Transform _camera;
    public Transform _ball;
    // Use this for initialization

    private void SetLevel(int level)
    {
        Vector3 target;
        target = _camera.position;
        target.y = target.y + 10.24f * level;
        _camera.position = target;
        target = _ball.position;
        target.y = target.y + 10.24f * level;
        _ball.position = target;
    } 
    
    private void Awake()
    {
        if (ToolManager.Instance == null)
        {
            GameObject.Instantiate(gamemanager);
        }

        GameObject.Find("PlayerName").GetComponent<Text>().text = "Name: " + PlayerPrefs.GetString("player name");
        GameObject.Find("Score").GetComponent<Text>().text = "Score: 0";
        GameObject.Find("Height").GetComponent<Text>().text = "Height: 0";
        PlayerPrefs.SetInt("max height", 0);
        PlayerPrefs.SetInt("score", 0);
        SetLevel(PlayerPrefs.GetInt("level"));
        //ToolManager.Instance.ball = GameObject.FindGameObjectWithTag("Player");
        ToolManager.Instance.IniToolmanager(); 
    }
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
