using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachLevel : MonoBehaviour {

    public float minCamPos = -5f;
    public float maxCamPos = 30f;
    // Use this for initialization
    void Start () {
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().SetRange(minCamPos, maxCamPos);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
