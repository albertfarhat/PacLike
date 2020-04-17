using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : PropertyDrawer
    {
        private const string PROPERTY_VALUE = "ConstantValue";
        private const string USE_CONSTANT = "UseConstant";
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            bool useConstant = property.FindPropertyRelative(USE_CONSTANT).boolValue;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var rect = new Rect(position.position, Vector2.one * 20);
            if (EditorGUI.DropdownButton(rect,
                new GUIContent(GetTexture()),
                FocusType.Keyboard, new GUIStyle()
                {
                    fixedWidth = 50f,
                    border = new RectOffset(1, 1, 1, 1)
                }
            ))
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Constant"),
                    useConstant,
                    () => SetProperty(property, true));

                menu.AddItem(new GUIContent("Variable"),
                    !useConstant,
                    () => SetProperty(property, false));

                menu.ShowAsContext();
            };

            position.position += Vector2.right * 15;
            float value = property.FindPropertyRelative(PROPERTY_VALUE).floatValue;
            if (useConstant)
            {
                string newValue = EditorGUI.TextField(position, value.ToString());
                float.TryParse(newValue, out value);
                property.FindPropertyRelative(PROPERTY_VALUE).floatValue = value;

            }
            else
            {
                EditorGUI.ObjectField(position, property.FindPropertyRelative("Variable"), GUIContent.none);
            }
            EditorGUI.EndProperty();
        }

        private void SetProperty(SerializedProperty property, bool value)
        {
            var propRelative = property.FindPropertyRelative(USE_CONSTANT);
            propRelative.boolValue = value;
            property.serializedObject.ApplyModifiedProperties();
        }

        private Texture GetTexture()
        {           
            var texture = Resources.FindObjectsOfTypeAll(typeof(Texture))
                 .Where(t => t.name.ToLower().Contains("arrow"))
             .Cast<Texture>().FirstOrDefault();
            return texture;
        }

    }
}
