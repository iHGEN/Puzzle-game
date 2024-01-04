using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AddCollider))]
public class meshcollider : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AddCollider collider = (AddCollider)target;
        if (GUILayout.Button("Add"))
        {
            collider.add_collider();
        }
        if (GUILayout.Button("Delete"))
        {
            collider.Delete_collider();
        }
    }
}
