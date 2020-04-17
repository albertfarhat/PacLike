using System;
using UnityEngine;
public class IdleState : BaseState
{
    private Ghost _ghost;
    private FloatVariable _timer;
    private float _currentTime;
    public IdleState(Ghost ghost, FloatVariable maxTime) : base(ghost.gameObject)
    {
        _ghost = ghost;
        _timer = maxTime;
    }

    public override Type Tick()
    {
        Debug.Log("Idle");
        if (_currentTime < _timer.Value)
            _currentTime += Time.deltaTime;
        else
        {
            _currentTime = 0;
            return typeof(WanderState);
        }
        return null;
    }
}
