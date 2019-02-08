using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    public bool clockwise = true;
    public float speed = 30.0f;

    private void Start()
    {
        if (speed < 0)
            speed = 0;        
    }

    void Update()
    {
        Vector3 rotate = Vector3.zero;
        if (clockwise)
            rotate.z = -Time.deltaTime * speed;
        else
            rotate.z = Time.deltaTime * speed;
        transform.Rotate(rotate);
    }
}
