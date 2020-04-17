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

    private bool _powerUpOn = false;

    private void Awake()
    {

        LevelEvents.Current.OnPowerUpConsumed += Current_OnPowerUpConsumed;
        LevelEvents.Current.OnPowerUpFinished += Current_OnPowerUpFinished;

        _playerHealth.CurrentHealth.Value = _playerHealth.MaxHealth.Value;
    }

    private void Current_OnPowerUpFinished()
    {
        _powerUpOn = false;
    }

    private void Current_OnPowerUpConsumed()
    {
        _powerUpOn = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.ToLower().Contains("ghost"))
        {
            if (!_powerUpOn)
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


    private void OnDestroy()
    {

        LevelEvents.Current.OnPowerUpConsumed -= Current_OnPowerUpConsumed;
        LevelEvents.Current.OnPowerUpFinished -= Current_OnPowerUpFinished;
    }
}
