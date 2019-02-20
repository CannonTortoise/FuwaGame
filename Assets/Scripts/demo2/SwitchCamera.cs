using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    public Transform _camera;
    public float speed = 1.0f;
    private Vector3 target;

    private void Start()
    {
        target = _camera.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball") {
            target.y = target.y + 10.24f;
            _camera.position = target;
            Destroy(this);
        }  
    }

}
