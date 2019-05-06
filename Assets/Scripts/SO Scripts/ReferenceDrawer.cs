using UnityEditor;
using UnityEngine;

/// <summary>
/// ReferenceDrawer Class.
/// </summary>
[CustomPropertyDrawer(typeof(Reference), true)]
public class ReferenceDrawer : PropertyDrawer
{
    /// <summary>
    /// Options to display in the popup to select constant or variable.
    /// </summary>
    private readonly string[] _PopupOption = { "Use Constant", "Use Variable" };

    /// <summary> Cached style to use to draw the popup button. </summary>
    private GUIStyle _PopupStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (_PopupStyle == null)
        {
            _PopupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
            _PopupStyle.imagePosition = ImagePosition.ImageOnly;
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck();

        // Get properties
        SerializedProperty useConstant = property.FindPropertyRelative("UseConstant");
        SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
        SerializedProperty variable = property.FindPropertyRelative("Variable");

        // Calculate rect for configuration button
        Rect buttonRect = new Rect(position);
        buttonRect.yMin += _PopupStyle.margin.top;
        buttonRect.width = _PopupStyle.fixedWidth + _PopupStyle.margin.right;
        position.xMin = buttonRect.xMax;

        // Store old indent level and set it to 0, the PrefixLabel takes care of it
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, _PopupOption, _PopupStyle);
        useConstant.boolValue = result == 0;
        EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variable, GUIContent.none);

        if (EditorGUI.EndChangeCheck())
            property.serializedObject.ApplyModifiedProperties();

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}