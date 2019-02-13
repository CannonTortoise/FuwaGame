using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
=======

>>>>>>> 0f70ee919e341dd2e9702201c82eef681fe1fa83
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
<<<<<<< HEAD
=======

>>>>>>> 0f70ee919e341dd2e9702201c82eef681fe1fa83
    }
}
