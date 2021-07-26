using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoteCharter))]


public class DicShower : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            EditorGUILayout.LabelField("Dictionary: ");
            foreach (var p in ((NoteCharter)target).NoteTime)
            {
                EditorGUILayout.LabelField("\t"+p.Key + ":" + p.Value);
            }
        }


    }
}
