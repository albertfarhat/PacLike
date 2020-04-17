using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int _levelNumber = 0;

    [SerializeField]
    private IntVariable _playerScore;

    [SerializeField]
    private LevelStatusVariable _currentLevelStatus;


    [SerializeField]
    private float _vurnabilityTime = 1f;
    private float _vurnabilityTimer = 0;

    [SerializeField]
    private GameObject _coins;

    [SerializeField]
    private GameObject _powerConis;

    private bool _startPowerUpTimer = false;

    // Start is called before the first frame update
    private void Awake()
    {
        LevelEvents.Current.OnPowerUpConsumed += Current_OnPowerUpConsumed;
        
        _currentLevelStatus.Value = LevelStatus.Started;
        _playerScore.Value = 0;

    }

    private void Current_OnPowerUpConsumed()
    {
        _startPowerUpTimer = true;
        _vurnabilityTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLevelCompleted())
            _currentLevelStatus.Value = LevelStatus.Completed;

        if (_currentLevelStatus.Value == LevelStatus.Paused)
            if (Input.GetKeyDown(KeyCode.Space))
                _currentLevelStatus.Value = LevelStatus.Started;


        if (_startPowerUpTimer)
            RunPowerUpTimer();
    }

    private void RunPowerUpTimer()
    {
        _vurnabilityTimer += Time.deltaTime;
        if (_vurnabilityTimer > _vurnabilityTime)
        {
            _startPowerUpTimer = false;
            LevelEvents.Current.PowerUpFinished();
             _vurnabilityTimer = 0;
        }
    }

    private bool IsLevelCompleted()
    {
        return _coins.transform.childCount == 0 
            && _powerConis.transform.childCount == 0;

    }

    private void OnDestroy()
    {
        LevelEvents.Current.OnPowerUpConsumed -= Current_OnPowerUpConsumed;
    }
}

