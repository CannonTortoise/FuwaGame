using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMove : MonoBehaviour {
    public Text lifeText;
    public GameObject ball;
	// Use this for initialization
	void Start () {
        lifeText.text = "100%";
        ball = GameObject.FindGameObjectWithTag("Player");

		
	}
	
	// Update is called once per frame
	void Update () {
        lifeText.GetComponent<Transform>().position = ball.GetComponent<Transform>().position - new Vector3(0, 1, 0);
	}
}
