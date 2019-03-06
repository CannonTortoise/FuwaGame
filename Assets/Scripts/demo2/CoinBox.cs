using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {

    public GameObject coin;

	// Use this for initialization
	void Start () {
        coin.SetActive(false);
        bool coinvisible = false;
        //GameObject coin = (GameObject)Resources.Load("Resources/Coin");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 speed = GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity;
        //print(speed);
        if (speed.y >= 0 && coin!=null )
            coin.SetActive(true);
    }

}
