using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagController : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
           // print("1");
            //collision.gameObject.GetComponent<CoinMove>().autoMove= true;
            //Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
