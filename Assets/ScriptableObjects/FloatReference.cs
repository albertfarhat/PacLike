using System;
using UnityEngine;



[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue = 0;
    public FloatVariable Variable;
    public float Value
    {
        get
        {
            return UseConstant ? ConstantValue : Variable.Value;
        }
        set
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
    }
}
