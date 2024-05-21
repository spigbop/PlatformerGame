using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextEngine))]
public class TextEngineEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        TextEngine _base = target as TextEngine;
        if(GUILayout.Button("Build Text Objects")) {
            _base.font.Translate();
            _base.Print();
        }
        //if(GUILayout.Button("Clear All Children")) {
        //    foreach(Transform _child in _base.transform) {
        //        DestroyImmediate(_child.gameObject, false);
        //    }
        //}
    }
}
