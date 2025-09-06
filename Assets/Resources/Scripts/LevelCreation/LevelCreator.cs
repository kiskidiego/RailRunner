using UnityEngine;

[ExecuteInEditMode]
public class LevelCreator : MonoBehaviour
{
    public NodeEditor NodePrefab;
    private Level currentLevelInstance;
    public string levelName = "NewLevel";
    public void ResetLevel()
    {
        if (currentLevelInstance != null)
        {
            DestroyImmediate(currentLevelInstance.gameObject);
        }
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
    public void CreateNewNode()
    {
        NodeEditor newNode = new GameObject().AddComponent<NodeEditor>();
        newNode.nodeIndex = transform.childCount;
        newNode.transform.parent = transform;
    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).GetComponent<NodeEditor>();
            if (child != null)
            {
                child.nodeIndex = i;
                child.gameObject.name = "Node_" + i;
            }
        }
    }
}