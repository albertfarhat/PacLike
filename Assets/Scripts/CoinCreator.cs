using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinPrefab;

    [SerializeField]
    private float _coinSpacing = 1;

    [SerializeField]
    private float _numberOfCoins = 25;
    private void Awake()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        var x = transform.position.x;
        for(int i = 0; i < _numberOfCoins; i++)
        {
            x += _coinSpacing;
            Vector3 vector = new Vector3(x, transform.position.y);
           var coin =  Instantiate(_coinPrefab, vector, Quaternion.identity);
            coin.transform.parent = gameObject.transform;

        }       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
