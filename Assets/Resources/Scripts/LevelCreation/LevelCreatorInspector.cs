using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(LevelCreator))]
public class LevelCreatorInspector : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        var inspector = new VisualElement();

        // Add the default inspector
        var defaultInspector = new IMGUIContainer(() => DrawDefaultInspector());
        inspector.Add(defaultInspector);

        // Add a button to reset the level
        var resetButton = new Button(() => ((LevelCreator)target).ResetLevel())
        {
            text = "Reset Level"
        };
        inspector.Add(resetButton);

        // Add a button to create a new level node
        var createNodeButton = new Button(() => ((LevelCreator)target).CreateNewNode())
        {
            text = "Create New Node"
        };
        inspector.Add(createNodeButton);

        return inspector;
    }
}