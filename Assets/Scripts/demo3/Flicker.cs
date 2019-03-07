using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {

    private float totalTime;
    private float timer;
    public float intervalTime;
    public Color flickColor;
    public SpriteRenderer turtleSprite;

    private void Start()
    {
        totalTime = 0f;
        timer = 0f;
        
    }

    public void Begin(float Time)
    {
        turtleSprite.color = flickColor;
        totalTime = Time;
        timer = 0f;
    }

    public void ResetTimer()
    {
        totalTime = 0;
        timer = 0;
        turtleSprite.enabled = true ;
        turtleSprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime == 0)
            return;
        if (timer < totalTime) {
            if(timer % intervalTime > intervalTime/2)
                turtleSprite.enabled = true;
            else
                turtleSprite.enabled = false;
            timer += Time.deltaTime;
        }
        else {
            ResetTimer();
        }
    }
}
