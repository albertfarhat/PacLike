﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
 
    [SerializeField]
    private IntVariable _playerScore;
    [SerializeField]
    private IntVariable _coinValue;

    [SerializeField]
    private BoolVariable _ghostVurnable;

    private AudioSource _audioPlayer;

   
    private void Awake()
    {
        _audioPlayer = GetComponentInParent<AudioSource>();
        _audioPlayer.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(transform.parent.name.ToLower() == "powercoins")
            {
                _ghostVurnable.Value = true;
            }
            _audioPlayer.Play();
            _playerScore.Value += _coinValue.Value;
            Destroy(gameObject);
        }
    }


}
