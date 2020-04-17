using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerScoreText : MonoBehaviour
{
    [SerializeField]
    private IntVariable _playerScore;
    private TMP_Text _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        string value = _playerScore.Value.ToString().PadLeft(8, '0');
        _text.text = (value);
    }
}
