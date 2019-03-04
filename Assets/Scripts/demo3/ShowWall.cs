using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWall : MonoBehaviour {

    private bool show = false;
    private float Time = 1.0f;

	// Use this for initialization
	void Start () {
        show = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (show)
        {
            this.transform.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else
        {
            this.transform.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
	}

    private void ResetWall()
    {
        show = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            show = true;
            Invoke("ResetWall", Time);
        }
    }

}
