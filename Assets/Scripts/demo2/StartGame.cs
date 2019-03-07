using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public int level;
    public GameObject levelsUI;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        //if (!PlayerPrefs.HasKey("highest score") || PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highest score"))
        //{
        //    PlayerPrefs.SetString("highest name", PlayerPrefs.GetString("player name"));
        //    PlayerPrefs.SetInt("highest score", PlayerPrefs.GetInt("score"));
        //}
        //GameObject.Find("HighestScore").GetComponent<Text>().text = "Highest Score: \n" +
        //PlayerPrefs.GetString("highest name") + " " + System.Convert.ToString(PlayerPrefs.GetInt("highest score"));
        //PlayerPrefs.SetString("player name", null);
        //PlayerPrefs.SetInt("score", 0);
        //PlayerPrefs.SetInt("level", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartLevel(string Level) {
        if (PlayerPrefs.GetString("player name") == null)
            PlayerPrefs.SetString("player name", "Turtle");
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", level);
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
    }

    public void ChooseLevel(int n)
    {
        if (PlayerPrefs.GetString("player name") == null)
            PlayerPrefs.SetString("player name", "Turtle");
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("level", n);
        SceneManager.LoadScene("level2.0");
        Time.timeScale = 1;
    }

    public void Continue() {
        GameObject.Find("Start").SetActive(false);
        GameObject.Find("Continue").SetActive(false);
        levelsUI.SetActive(true);
    }

    public void Select()
    {
        GameObject.Find("Select").SetActive(false);
        GameObject.Find("Return").SetActive(false);
        GameObject.Find("Continue").SetActive(false);
        levelsUI.SetActive(true);
    }

}
