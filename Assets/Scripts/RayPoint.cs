using UnityEngine;

public class RayPoint
{
    private  Vector3 _position;
    private readonly DirectionVector _directionVector;
    public Vector3 Position => _position;
    public DirectionVector DirectionVector => _directionVector;

    public RayPoint(Vector3 position,DirectionVector directionVector)
    {
        _position = position;
        _directionVector = directionVector;
    }

    public void SetPosition(Vector3 position)
    {
        _position = position;
    }
}


