using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int damage;
    private LifeMove lm;
	// Use this for initialization
	void Start () {
        lm = GameObject.Find("Ball").GetComponent<LifeMove>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
            lm.ReduceHP(damage);
    }
}
