using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
    //这个脚本用来控制每个场景中唯一只有一个GameManager
    public GameObject gamemanager;
    // Use this for initialization
    private void Awake()
    {
        if (ToolManager.Instance == null)
        {
            GameObject.Instantiate(gamemanager);
        }

    }
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
