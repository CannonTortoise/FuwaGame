using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

    public GameObject restartUI;

    public void Restart()
    {
        SceneManager.LoadScene("start");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Ball" )
        {
            
            restartUI.SetActive(true);
        }
    }
}
