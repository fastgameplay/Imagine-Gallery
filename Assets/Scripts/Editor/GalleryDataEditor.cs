using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Scr_GalleryData))]
public class GalleryDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Scr_GalleryData script = (Scr_GalleryData)target;

            if(GUILayout.Button("Reset Data", GUILayout.Height(40)))
            {
                script.Reset();
            }
        
    }
}
