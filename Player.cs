using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private access but editable in inspector, this variable is for speed
    [SerializeField] private float _moveSpeed = 3.5f;

    //Axis
    private float _xAxis = 0.0f, _yAxis = 0.0f;

    //Movement
    private Vector3 _dir = Vector3.zero;
    // private Vector2 _dir = Vector2.zero;


    // Update is called once per frame
private void Update()
{
    // Reset axes to 0 at the start of each frame
    _xAxis = 0.0f;
    _yAxis = 0.0f;

    // Handle vertical movement (W and S keys)
    if (Input.GetKey(KeyCode.W))
    {
        _yAxis = 1.0f;
    }
    else if (Input.GetKey(KeyCode.S))
    {
        _yAxis = -1.0f;
    }

    // Handle horizontal movement (A and D keys)
    if (Input.GetKey(KeyCode.D))
    {
        _xAxis = 1.0f;
    }
    else if (Input.GetKey(KeyCode.A))
    {
        _xAxis = -1.0f;
    }

    // If there is any input, call the Movement method
    if (_xAxis != 0.0f || _yAxis != 0.0f)
    {
        Movement(_xAxis, _yAxis);
    }
}

private void Movement(float x, float y)
{
    // Calculate direction and normalize it
    _dir = (transform.right * x + transform.up * y).normalized;

    // Move the object
    transform.position += _dir * _moveSpeed * Time.deltaTime;
}
}