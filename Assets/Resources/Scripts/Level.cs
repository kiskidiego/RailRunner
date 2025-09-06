using UnityEngine;

public class Level : MonoBehaviour
{
    private class LevelNode
    {
        public int[] neighborNodes;
        public Vector3[][] paths;
        public Vector3 position;
        public int index;
    }
    private LevelNode[] levelNodes;
    /// <summary>
    /// Returns the path from one node to another as an array of Vector3 positions.
    /// </summary>
    /// <param name="fromNode">The index of the starting node.</param>
    /// <param name="toNode">The index of the target node.</param>
    /// <returns>An array of Vector3 representing the path from the starting node to the target node.</returns>
    public Vector3[] GetPathToNode(int fromNode, int toNode)
    {
        if (levelNodes == null || fromNode < 0 || fromNode >= levelNodes.Length || toNode < 0 || toNode >= levelNodes.Length)
        {
            Debug.LogError("Invalid node indices or level nodes not initialized.");
            return null;
        }

        LevelNode startNode = levelNodes[fromNode];
        for (int i = 0; i < startNode.neighborNodes.Length; i++)
        {
            if (startNode.neighborNodes[i] == toNode)
            {
                Vector3[] path = new Vector3[startNode.paths[i].Length + 1];
                return startNode.paths[i];
            }
        }

        Debug.LogError($"No direct path from node {fromNode} to node {toNode}.");
        return null;
    }
    /// <summary>
    /// Returns an array of Vector4 where x,y,z are the position of each neighbor node and w is the index of that node.
    /// </summary>
    /// <param name="nodeIndex">The index of the node whose neighbors are being requested.</param>
    /// <returns>An array of Vector4 representing the positions and indices of the neighbor nodes.</returns>
    public Vector4[] GetNodeNeighbors(int nodeIndex)
    {
        if (levelNodes == null || nodeIndex < 0 || nodeIndex >= levelNodes.Length)
        {
            Debug.LogError("Invalid node index or level nodes not initialized.");
            return null;
        }

        LevelNode node = levelNodes[nodeIndex];
        Vector4[] neighborPositions = new Vector4[node.neighborNodes.Length];
        for (int i = 0; i < node.neighborNodes.Length; i++)
        {
            int neighborIndex = node.neighborNodes[i];
            if (neighborIndex >= 0 && neighborIndex < levelNodes.Length)
            {
                LevelNode neighborNode = levelNodes[neighborIndex];
                neighborPositions[i] = new Vector4(
                    neighborNode.position.x,
                    neighborNode.position.y,
                    neighborNode.position.z,
                    neighborNode.index
                );
            }
            else
            {
                Debug.LogError($"Invalid neighbor index {neighborIndex} for node {nodeIndex}.");
                neighborPositions[i] = new Vector4(
                    node.position.x,
                    node.position.y,
                    node.position.z,
                    node.index
                );
            }
        }
        return neighborPositions;
    }
}
