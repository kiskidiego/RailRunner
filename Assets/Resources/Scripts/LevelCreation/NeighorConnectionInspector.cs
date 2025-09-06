using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(NodeEditor.NeighborConnection))]
public class NeighborConnectionInspector : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        var inspector = new VisualElement();

        // Add the default inspector
        var defaultInspector = new IMGUIContainer(() => DrawDefaultInspector());
        inspector.Add(defaultInspector);

        // Add a button to create a new path point
        var addPathPointButton = new Button(() => ((NodeEditor.NeighborConnection)target).AddPathPoint())
        {
            text = "Add Path Point"
        };
        inspector.Add(addPathPointButton);

        return inspector;
    }
}