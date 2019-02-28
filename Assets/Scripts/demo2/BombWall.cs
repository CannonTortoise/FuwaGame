using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Player" && ToolManager.Instance.withBombBall == true && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
