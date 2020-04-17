using UnityEngine;

public class DirectionVector
{

    public static DirectionVector Right = new DirectionVector(Direction.Right, Vector3.right);
    public static DirectionVector Left = new DirectionVector(Direction.Left, Vector3.left);
    public static DirectionVector Top = new DirectionVector(Direction.Up, Vector3.up);
    public static DirectionVector Bottom = new DirectionVector(Direction.Down, Vector3.down);


    private readonly Vector3 _vector;
    private Direction _direction;
    public DirectionVector(Direction direction,Vector3 vector)
    {
        _vector = vector;
        _direction = direction;
    }

    public Direction Direction=> _direction;
    public Vector3 Vector => _vector;
}



