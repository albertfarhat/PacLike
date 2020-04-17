using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth;
    [SerializeField]
    private GameObject _startPosition;
    [SerializeField]
    private LevelStatusVariable _currentLevelStatus;
    [SerializeField]
    private BoolVariable _ghostVunrable;
   

    private void Awake()
    {
        _playerHealth.CurrentHealth.Value = _playerHealth.MaxHealth.Value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.ToLower().Contains("ghost"))
        {
            if (!_ghostVunrable.Value)
            {
                if (_playerHealth.CurrentHealth.Value > 0)
                {
                    _playerHealth.CurrentHealth.Value--;
                    transform.position = _startPosition.transform.position;
                    _currentLevelStatus.Value = LevelStatus.Paused;
                }
                else
                {
                    _currentLevelStatus.Value = LevelStatus.Failed;
                }
            }          
        }
    }
}
