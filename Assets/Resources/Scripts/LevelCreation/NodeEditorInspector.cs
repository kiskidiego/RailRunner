using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodeEditor))]
public class NodeEditorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        NodeEditor nodeEditor = (NodeEditor)target;

        if (GUILayout.Button("Add Neighbor Connection"))
        {
            nodeEditor.AddNeighborConnection();
        }
    }
}
