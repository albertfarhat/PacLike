//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Ghost : MonoBehaviour
{
    [SerializeField]
    private FloatReference _speed;
    [SerializeField]
    private int _ghostId;
    [SerializeField]
    private LevelStatusVariable _currentLevelStatus;
    [SerializeField]
    private BoolVariable _ghostVunrable;
 
    [SerializeField]
    private GameObject _leftTopRayPoint;
    [SerializeField]
    private GameObject _leftBottomRayPoint;
    [SerializeField]
    private GameObject _rightTopRayPoint;
    [SerializeField]
    private GameObject _rightBottomRayPoint;
    [SerializeField]
    private GameObject _topRightRayPoint;
    [SerializeField]
    private GameObject _topLeftRayPoint;
    [SerializeField]
    private GameObject _bottomRightRayPoint;
    [SerializeField]
    private GameObject _bottomLeftRayPoint;

    [SerializeField]
    private Direction _initialDirection;
    private GhostMovementAI _momventAi;

    [SerializeField]
    private bool _drawRay = true;

    [SerializeField]
    private bool _drawChangeRay = true;
    
    [SerializeField]
    private float _rayDuration = 0.3f;

    [SerializeField]
    private float _changeRayDuration = 0.3f;

    [SerializeField]
    private float _changeDirectionTime = 2.0f;
    // public Transform Target { get; private set; }


    private Rigidbody2D _rigidBody;
    private SpriteRenderer _sprite;
    private Vector3 _initPosition;
    private RayPerimeter _rayPerimeter;
    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _momventAi = new GhostMovementAI(_initialDirection,
            _speed.Value,
            drawChangeRay: _drawChangeRay,
            drawRay: _drawRay,
            rayDuration: _rayDuration,
            changeRayDuration:_changeRayDuration,
            changeDirectionTime: _changeDirectionTime
            );
        _momventAi.Stop += Stop;
        _initPosition = transform.position;      
    }

    private void Stop(bool stop)
    {
        transform.transform.Translate(Vector3.zero);
    }

    void Update()
    {

        if (_ghostVunrable.Value && _sprite.color == Color.white)
        {
            _sprite.color = new Color(0, 129, 190);
        }
        else if (!_ghostVunrable.Value && _sprite.color != Color.white)
        {
            _sprite.color = Color.white;
        }

        if (_currentLevelStatus.Value == LevelStatus.Started)
        {
            SetRayPerimeter();
            transform.Translate(_momventAi.Move(true, _rayPerimeter));
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }
    }

    private void SetRayPerimeter()
    {
        _rayPerimeter = new RayPerimeter(
            _rightBottomRayPoint.transform.position,
            _rightTopRayPoint.transform.position,
            _leftBottomRayPoint.transform.position,
            _leftTopRayPoint.transform.position,
            _topRightRayPoint.transform.position,
            _topLeftRayPoint.transform.position,
            _bottomRightRayPoint.transform.position,
            _bottomLeftRayPoint.transform.position);
    }
    //public void SetTarget(Transform target)
    //{
    //    Target = target;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player" && _ghostVunrable.Value)
        {
            transform.position = _initPosition;
        }
    }


}
