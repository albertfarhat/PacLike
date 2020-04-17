using UnityEngine;

public class RayPerimeter
{
    private readonly RayPoint _rightTop;
    private readonly RayPoint _rightBottom;
    private readonly RayPoint _leftTop;
    private readonly RayPoint _leftBottom;
    private readonly RayPoint _topRight;
    private readonly RayPoint _topLeft;
    private readonly RayPoint _bottomRight;
    private readonly RayPoint _bottomLeft;

    public RayPerimeter(Vector3 rightTopPosition,
        Vector3 rightBottomPosition,
        Vector3 leftTopPosition,
        Vector3 leftBottomPosition,
        Vector3 topRightPosition,
        Vector3 topLeftPosition,
        Vector3 bottomRightPosition,
         Vector3 bottomLeftPosition)
    {
        _rightTop = new RayPoint(rightTopPosition, DirectionVector.Right);
        _rightBottom = new RayPoint(rightBottomPosition, DirectionVector.Right);
        _leftTop = new RayPoint(leftTopPosition, DirectionVector.Left);
        _leftBottom = new RayPoint(leftBottomPosition, DirectionVector.Left);
        _topRight = new RayPoint(topRightPosition, DirectionVector.Top);
        _topLeft = new RayPoint(topLeftPosition, DirectionVector.Top);
        _bottomRight = new RayPoint(bottomRightPosition, DirectionVector.Bottom);
        _bottomLeft = new RayPoint(bottomLeftPosition, DirectionVector.Bottom);
    }

    public (RayPoint one,RayPoint two) GetRayPoint(Direction direction)
    {
        switch (direction)
        {
            case Direction.Down:
                return (BottomRight, BottomLeft);
            case Direction.Up:
                return (TopRight, TopLeft);
            case Direction.Left:
                return (LeftTop,LeftBottom);
            case Direction.Right:
                return (RightTop,RightBottom);
        }
        return (null,null);
    }


    public RayPoint RightTop => _rightTop;
    public RayPoint RightBottom => _rightBottom;
    public RayPoint LeftTop =>_leftTop;
    public RayPoint LeftBottom => _leftBottom;
    public RayPoint TopRight =>_topRight;
    public RayPoint TopLeft => _topLeft;
    public RayPoint BottomRight =>_bottomRight;
    public RayPoint BottomLeft => _bottomLeft;
}


