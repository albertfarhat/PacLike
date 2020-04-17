using UnityEngine;
using System;
public enum Direction
{
    Idle,
    Right,
    Left,
    Up,
    Down
}
public class GhostMovementAI
{
    public static Vector3 DirectionToVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector3.up;
            case Direction.Down:

                return Vector3.down;
            case Direction.Right:

                return Vector3.right;
            case Direction.Left:

                return Vector3.left;
            default:

                return Vector3.zero;
        }
    }
    private readonly float _timeToCahngeDirection = 2.0f;
    private float _currentTimer = 0f;
    private readonly float _rayDuration = 0.01f;
    private readonly float _changeRayDuration = 0.1f;
    private readonly bool _drawRay;
    private readonly bool _drawChangeRay;
    private readonly float ghostSpeed;
    private Vector3 _currentVector;
    private Direction _currentDirection;
    public Direction CurrentDirection => _currentDirection;
    public Vector3 CurrentVector => _currentVector;


    public Action<bool> Stop = delegate { };

    public GhostMovementAI(Direction initDirection,
        float ghostSpeed,
        float changeDirectionTime = 2.0f,
        float rayDuration=0.1f,
        float changeRayDuration = 0.1f,
        bool drawRay = true,
        bool drawChangeRay=true)
    {
        _timeToCahngeDirection = changeDirectionTime;
        _rayDuration = rayDuration;
        _currentDirection = initDirection;
        _changeRayDuration = changeRayDuration;
        _drawRay = drawRay;
        this._drawChangeRay = drawChangeRay;
        this.ghostSpeed = ghostSpeed;
        _currentVector = DirectionToVector(_currentDirection);
    }
   
    public Vector3 Move(bool drawRay,RayPerimeter rayPerimeter)
    {
        var force = CurrentVector * ghostSpeed * Time.deltaTime;        

        var position = rayPerimeter.GetRayPoint(CurrentDirection);

        if (CastRay(position.one.Position, force, drawRay)
            || CastRay(position.two.Position,force,drawRay))
        {
            Stop(true);
            _currentTimer = 0;
            ApplyDirection(rayPerimeter, position);        
        }
        else
        {
            _currentTimer += Time.deltaTime;
            if(_currentTimer >= _timeToCahngeDirection)
            {
                _currentTimer = 0;
                ApplyDirection(rayPerimeter, position);  
            }
        }
        return force;
    }

    private (RayPoint one,RayPoint two) ApplyDirection(RayPerimeter rayPerimeter, 
        (RayPoint one, RayPoint two) position)
    {
        _currentDirection = FindNextDirection(rayPerimeter, CurrentDirection);
        _currentVector = DirectionToVector(_currentDirection);
        position = rayPerimeter.GetRayPoint(CurrentDirection);
        if (_drawChangeRay)
        {
            Debug.DrawRay(position.one.Position, CurrentVector, Color.red, _changeRayDuration);
            Debug.DrawRay(position.two.Position, CurrentVector, Color.red, _changeRayDuration);
        }       
        return position;
    }

    private Direction FindNextDirection(RayPerimeter rayPerimeter, Direction direction)
    {
        var randomVal = direction;
        while (randomVal == direction)
        {
            randomVal = (Direction)UnityEngine.Random.Range(1, 5);
        }
        var position = rayPerimeter.GetRayPoint(randomVal);
        if (!CheckDirection(randomVal,position.one.Position)
          || !CheckDirection(randomVal, position.two.Position))
            FindNextDirection(rayPerimeter, randomVal);
        return randomVal;
    }

    private bool CheckDirection(Direction direction,Vector3 rayPoint)
    {
        float rayDistance = 1.0f;
        var vector = DirectionToVector(direction);
        if(_drawChangeRay)
            Debug.DrawRay(rayPoint, vector * rayDistance, Color.green, _rayDuration);
       
        var hit = Physics2D.Raycast(rayPoint, vector, rayDistance);
        if (hit.collider == null || hit.collider.name.ToLower() != "background")
            return true;

        return false;
    }

    private bool CastRay(Vector3 position,Vector2 force,bool drawRay)
    {
        if (_drawRay)
        {
            Debug.DrawRay(position, _currentVector * 0.1f, Color.white, _rayDuration);
        }
        RaycastHit2D hit = Physics2D.Raycast(position, force,0.1f);
        return (hit.collider != null && hit.collider.name.ToLower().Contains("background"));                
    }
}
