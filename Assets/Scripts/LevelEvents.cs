using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelEvents : MonoBehaviour
{
    public static LevelEvents Current;

    private void Awake()
    {
        Current = this;
    }

    public event Action OnPowerUpConsumed;
    public event Action OnPowerUpFinished;

    public void PowerUpConsumed()
    {
        if(OnPowerUpConsumed != null)
        {
            OnPowerUpConsumed();
        }
    }

    public void PowerUpFinished()
    {
        if(OnPowerUpFinished != null)
        {
            OnPowerUpFinished();
        }
    }

}
