/*using UnityEditor;

//[CustomEditor(typeof(ButtonController))]
public class ButtonInspectorCustom : Editor
{

    #region SerializedProprietes
    SerializedProperty myText;

    SerializedProperty fadeToValue;
    SerializedProperty fadeDurationSeconds;
    SerializedProperty easeCurve;

    SerializedProperty arrow;

    bool animationGroup = false;
    #endregion

    private void OnEnable()
    {
        myText = serializedObject.FindProperty("mText");
        fadeToValue = serializedObject.FindProperty("fadeToValue");
        fadeToValue = serializedObject.FindProperty("fadeToValue");
        fadeDurationSeconds = serializedObject.FindProperty("fadeDruationSeconds");
        easeCurve = serializedObject.FindProperty("easeCurve");
        arrow = serializedObject.FindProperty("arrow");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        animationGroup = EditorGUILayout.BeginFoldoutHeaderGroup(animationGroup, "Animation");
        if (animationGroup)
        {
            EditorGUILayout.PropertyField(myText);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        serializedObject.ApplyModifiedProperties();
    }
}
*/