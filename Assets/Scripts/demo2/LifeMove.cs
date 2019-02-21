using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMove : MonoBehaviour {
    public Text lifeText;
    private int HP;
    public GameObject restartUI;

    public GameObject ball;
	// Use this for initialization
	void Start () {
        HP = 100;
        lifeText.text = "100%";
        ball = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (HP == 0)
            restartUI.SetActive(true);
        else if (HP <= 0)
            HP = 0;
        lifeText.text = HP + "%";
        lifeText.GetComponent<Transform>().position = ball.GetComponent<Transform>().position - new Vector3(0, 1, 0);
        
	}

    public void ReduceHP(int n) {
        HP -= n;
    }

}
