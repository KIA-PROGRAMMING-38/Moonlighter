using System.Reflection;
using UnityEditor;
using UnityEngine;

public class FontChanger : EditorWindow
{
    private static FontChanger window;

    private Font changeFont;
    private int changeFontSize;

    [MenuItem("Tools/Font Switcher")]
    private static void Init()
    {
        window = GetWindow<FontChanger>();
    }

    private void OnGUI()
    {
        changeFont = EditorGUILayout.ObjectField("Font", changeFont, typeof(Font), false) as Font;
        changeFontSize = EditorGUILayout.IntField("FontSize", changeFontSize);

        GUILayout.Space(10f);
        if (GUILayout.Button("Apply"))
            ChangeFont(changeFont, changeFontSize);
        else if (GUILayout.Button("Reset"))
            ChangeFont(null, changeFontSize);

    }

    private void ChangeFont(Font font, int size)
    {
        BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty;
        PropertyInfo[] editorStyleInfos = typeof(EditorStyles).GetProperties(flags);
        PropertyInfo[] guiStyleInfos = GUI.skin.GetType().GetProperties();

        for (int i = 0; i < editorStyleInfos.Length; i++)
        {
            if (PropertyInfoExists(editorStyleInfos[i]))
            {
                GUIStyle style = editorStyleInfos[i].GetValue(null, null) as GUIStyle;
                style.font = font;
                style.fontSize = size;
            }
        }

        for (int i = 0; i < guiStyleInfos.Length; i++)
        {
            if (PropertyInfoExists(guiStyleInfos[i]))
            {
                GUIStyle style = guiStyleInfos[i].GetValue(GUI.skin, null) as GUIStyle;
                style.font = font;
                style.fontSize = size;
            }
        }

        for (int i = 0; i < GUI.skin.customStyles.Length; i++)
        {
            GUI.skin.customStyles[i].font = font;
            GUI.skin.customStyles[i].fontSize = size;
        }

        EditorWindow[] windows = Resources.FindObjectsOfTypeAll<EditorWindow>();
        for (int i = 0; i < windows.Length; i++)
            windows[i].Repaint();

        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
    }

    private bool PropertyInfoExists(PropertyInfo info)
    {
        if (string.IsNullOrEmpty(info.Name))
            return false;
        else if (info.PropertyType != typeof(GUIStyle))
            return false;
        else
            return true;
    }   

}
