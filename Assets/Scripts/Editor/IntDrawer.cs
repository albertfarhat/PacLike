using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    [CustomPropertyDrawer(typeof(int))]
    public class IntDrawer:PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            GUI.backgroundColor = Color.green;
            EditorGUI.PropertyField(position, property, GUIContent.none);           
            EditorGUI.EndProperty();
        }
    }
}
