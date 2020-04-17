using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager 
{
    private readonly float _maxSpeed = 10;
    private float _currentSpeed = 0;
    private bool _isHorizontal = false;
    public SpeedManager(bool isHorizontal, float maxSpeed)
    {
        _maxSpeed = maxSpeed;
        _isHorizontal = isHorizontal;
    }

    public Vector3 CalculateSpeed( float power)
    {
        if (power != 0)
        {
            if (_currentSpeed < _maxSpeed)
                _currentSpeed += 0.1f;
            else
                _currentSpeed = _maxSpeed;
        }
        else if (power == 0)
        {
            if (_currentSpeed > 0)
                _currentSpeed -= 0.1f;
            else
                _currentSpeed = 0;
        }
        var speed = power * Time.deltaTime * _currentSpeed;
        if (_isHorizontal)
            return Vector3.right * speed;
        else
            return Vector3.up * speed;

    }
}
