using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Status Variable")]
public class LevelStatusVariable : ScriptableObject
{
    public LevelStatus Value;

    public string Text
    {
        get
        {
            return Enum.GetName(typeof(LevelStatus), Value);
        }
    }
}



public enum LevelStatus
{
    Started,
    Paused,
    Stoped,
    Failed,
    Completed,
    Exited
}
