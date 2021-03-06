﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour {
    //public bool autoMove = false;
    public int megRange = 3;
    public float smoothing = 3;
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    public Vector3 targetpos;
    

    public void Move(GameObject destination)
    {
        
    }

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ToolManager.Instance.withMagnet == true )
        {if (GetComponentInParent<Pendulum>() != null)
            {
                print(gameObject.GetComponentInParent<Transform>().tag);
                GetComponentInParent<Pendulum>().enabled = false;
            }
            
            targetpos = GameObject.FindGameObjectWithTag("Player").transform.position;
            //print(megRange);
            if (Vector3.Distance(transform.position, targetpos) < megRange)
            {
                rigidbody.MovePosition(Vector2.Lerp(transform.position, targetpos, smoothing * Time.deltaTime));
            }
        }

    }
}
