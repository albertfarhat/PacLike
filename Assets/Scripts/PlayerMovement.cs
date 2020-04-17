using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;
    private Animator _animator;
    private SpeedManager _speedXManager;
    private SpeedManager _speedYManager;
    [SerializeField]
    private LevelStatusVariable _currentLevelStatus;

    private Rigidbody2D _rigidBody;

    [SerializeField]
    private GameObject _leftRayPoint;
    [SerializeField]
    private GameObject _rightRayPoint;
    [SerializeField]
    private GameObject _topRayPoint;
    [SerializeField]
    private GameObject _downRayPoint;
    private GameObject _rayPoint;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _speedXManager = new SpeedManager(true,_speed);
        _speedYManager = new SpeedManager(false, _speed);
    }   
    void Update()
    {
        if(_currentLevelStatus.Value != LevelStatus.Started)
        {
            _rigidBody.velocity = Vector2.zero;
            return;
        }

        var horizontal = Input.GetAxis("Horizontal");
        SetAnimation(horizontal);
        Move(true, horizontal);
        
        var vertical = Input.GetAxis("Vertical");
        Move(false, vertical);
       

    }

    private void SetAnimation(float axisInput)
    {
        if (axisInput > 0)
        {
            _animator.SetBool("GoingRight", true);
            _animator.SetBool("GoingLeft", false);
        }
        else if (axisInput < 0)
        {
            _animator.SetBool("GoingRight", false);
            _animator.SetBool("GoingLeft", true);
        }
        else
        {
            _animator.SetBool("GoingRight", false);
            _animator.SetBool("GoingLeft", false);
        }
    }
    private void Move(bool horizontal,float axisInput)
    {
        var vector = horizontal ? _speedXManager.CalculateSpeed(axisInput) : _speedYManager.CalculateSpeed(axisInput);
        var rayPoint = SelectRayPoint(!horizontal ? axisInput : 0, horizontal ? axisInput : 0);
        if (rayPoint != null)
        {
            float raySize = 0.1f;
           
            var hit = Physics2D.Raycast(rayPoint.transform.position, vector, raySize);
          
            Vector3 rayVector = new Vector3
            {
                x = !horizontal? 0: vector.x > 0 ? raySize : raySize * -1,
                y  = horizontal ? 0 : vector.x > 0 ? raySize : raySize * -1
            };

            Debug.DrawRay(rayPoint.transform.position, rayVector, Color.red);

            if (hit.collider != null)
            {
                if (!hit.collider.name.ToLower().Contains("background"))
                    transform.Translate(vector);
            }
            else
                transform.Translate(vector);
        }
    }

    private GameObject SelectRayPoint(float vertical,float horizontal)
    {
        if (vertical > 0)
            return _topRayPoint;
        
            if (vertical < 0)
            return _downRayPoint;

        if (horizontal > 0)
            return _rightRayPoint;

        if (horizontal < 0)
            return _leftRayPoint;
        return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    //    Debug.Log("Collision OnTriggerEnter2D");
      //  Destroy(collision.gameObject);
     //   Destroy(gameObject);
    }

}
