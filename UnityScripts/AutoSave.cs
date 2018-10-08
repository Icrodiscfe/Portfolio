#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AutoSave
{
    private static DateTime nextSaveTime;

    [InitializeOnLoadMethod]
    private static void OnInitializeOnLoadMethod() // Static constructor that gets called when unity fires up.
    {
        // Save scenes if we are entering play mode
        EditorApplication.playModeStateChanged -= Init; // remove all previously added callbacks
        EditorApplication.playModeStateChanged += Init;

        // Also, every "AutoSaveTime" minutes. (Default 5min, you can change them in "preferences" window)
        nextSaveTime = DateTime.Now.AddMinutes(AutoSaveTime);
        EditorApplication.update -= Update; // remove all previously added callbacks
        EditorApplication.update += Update;
    }

    private static void Init (PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            SaveScenes();
        }
    }

    private static void Update()
    {
        if (nextSaveTime > DateTime.Now) return;

        nextSaveTime = nextSaveTime.AddMinutes(AutoSaveTime);
        SaveScenes();
    }

    private static void SaveScenes()
    {
        bool isDirty = false; // Save only if any scene is dirty

        // Check if any open scene is marked as dirty
        for (int i = 0; i < EditorSceneManager.sceneCount; i++)
        {
            if (EditorSceneManager.GetSceneAt(i).isDirty)
            {
                isDirty = true;
                break;
            }
        }

        if (!isDirty)
        {
            return;
        }

        Debug.Log("AutoSave Scenes: " + DateTime.Now.ToShortTimeString());
        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.SaveAssets();
    }
    

    // Add "AutoSaveTime" to preference window
    static int AutoSaveTime
    {
        get
        {
            return EditorPrefs.GetInt("AutoSaveTime", 5);
        }

        set
        {
            EditorPrefs.SetInt("AutoSaveTime", value);
        }
    }

    [PreferenceItem("AutoSave")]
    private static void PrefWindowGUI()
    {
        EditorGUI.BeginChangeCheck();
        AutoSaveTime = EditorGUILayout.IntField("Auto save time", AutoSaveTime);
        if (AutoSaveTime < 1)
            AutoSaveTime = 1;
        if (EditorGUI.EndChangeCheck())
        {
            nextSaveTime = DateTime.Now.AddMinutes(AutoSaveTime);
        }
    }
}
#endif
