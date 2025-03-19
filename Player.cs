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
        if (Input.GetKeyDown(KeyCode.W))
        {
            _yAxis = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            _yAxis = -1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            _yAxis = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _xAxis = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _xAxis = -1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            _xAxis = 0.0f;
        }
        
        if (_xAxis != 0.0f || _yAxis != 0.0f)
        {
            Movement(_xAxis, _yAxis);
        }
        // Debug.Log($"Inputs: _xAxis: {_xAxis} _yAxis: {_yAxis}");
    }

    private void Movement (float x, float y)
    {
        //limits the values to be between -1 and 1
        _dir = (transform.right * x + transform.up * y).normalized;

        //Time.deltaTime is the time between frames
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }
}