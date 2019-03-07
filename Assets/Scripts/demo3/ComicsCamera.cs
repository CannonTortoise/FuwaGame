using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicsCamera : MonoBehaviour {

    private Vector3 target;
    public float speed;
    public Transform[] comics;
    private int cnt;
    public GameObject startUI;

	void Start () {
        target = transform.position;
        cnt = 0;
        PlayerPrefs.SetInt("level", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= target.y)
            transform.position = new Vector3(target.x, target.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed, transform.position.z);//改变相机的位置
    }


    public void ChangeTarget() {
        target = comics[++cnt].position;
        if (cnt == comics.Length - 1)
        {
            startUI.SetActive(true);
            GameObject.Find("Fli[").SetActive(false);
        }

    }
}
