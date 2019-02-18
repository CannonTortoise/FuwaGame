using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    const float TotalTime = 30;
    private float LeftTime;
    public Slider slider;
	// Use this for initialization
	void Awake () {
        LeftTime = TotalTime;
        slider.value = 1;

	}
	
	// Update is called once per frame
	void Update () {
		if (LeftTime > 0)
        {
            LeftTime -= Time.deltaTime;
            slider.value = LeftTime / TotalTime;
        }
	}
}
