using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public GameObject restartUI;

    public void Restart() {
        SceneManager.LoadScene("start");
    }

    public void Back()
    {
        SceneManager.LoadScene("start");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   if(collision.gameObject.name == "Ball" && ToolManager.Instance.withInvincibility == true)
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
            this.gameObject.GetComponent<Collider2D>().sharedMaterial.bounciness = 1;
        }
        if (collision.gameObject.name == "Ball" && ToolManager.Instance.withInvincibility == false)
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            this.gameObject.GetComponent<Collider2D>().sharedMaterial.bounciness = 0;
            restartUI.SetActive(true);
        }
    }
          
    
}
