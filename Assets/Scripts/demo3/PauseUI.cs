using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

    public void Pause() {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void ReturnToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("start");
    }
}
