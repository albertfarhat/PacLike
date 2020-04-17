using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player Health")]
public class PlayerHealth : ScriptableObject
{
    public IntReference MaxHealth;
    public IntReference CurrentHealth;
}
