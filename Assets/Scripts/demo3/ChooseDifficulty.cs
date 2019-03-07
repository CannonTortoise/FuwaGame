using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDifficulty : MonoBehaviour {

    public void ChooseHard() {
        PlayerPrefs.SetInt("Difficulty", 1);
    }
    public void ChooseEasy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
    }
    public void StartGame()
    {
        this.gameObject.SetActive(true);
        GameObject.Find("Continue").SetActive(false);
        GameObject.Find("Start").SetActive(false);
    }
}
