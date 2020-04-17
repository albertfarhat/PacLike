using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICurrentLevelStatus : MonoBehaviour
{

    [SerializeField]
    private LevelStatusVariable _currentLevelStatus;
    private TMP_Text _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
        if (_currentLevelStatus.Value == LevelStatus.Started)
        {
            _text.text = string.Empty;
            return;
        }


        _text.text = _currentLevelStatus.Text;
     

    }
}
