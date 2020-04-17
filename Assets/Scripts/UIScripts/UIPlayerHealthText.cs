using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthText : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _playerHealth.CurrentHealth.Value.ToString();
    }
}
