using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    public Transform _camera;
    private Vector3 target;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball") {
            target = _camera.position;
            target.y = target.y + 10.24f;
            _camera.position = target;
            Destroy(this);
        }  
    }

}
