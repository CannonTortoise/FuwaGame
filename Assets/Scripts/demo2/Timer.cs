using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float TotalTime;
    private float LeftTime;
    public Slider slider;
    public GameObject timer;
    public GameObject handle;
	// Use this for initialization
	void Awake () {
        //LeftTime = TotalTime;
        //slider.value = 1;
	}

    public void Begin(float Time)
    {
        //Image img = handle.GetComponent<Image>() as Image;
        //img.overrideSprite = Resources.Load(ImgPath, typeof(Sprite)) as Sprite;
        timer.SetActive(true);
        TotalTime = Time;
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
        else
        {
            timer.SetActive(false);
        }
	}
}
