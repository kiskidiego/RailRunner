using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode]
public class NodeEditor : MonoBehaviour
{
    [System.Serializable]
    public class NeighborConnection : MonoBehaviour
    {
        public NodeEditor neighborNode;
        public List<Transform> pathPoints = new List<Transform>();
        public void AddPathPoint()
        {
            GameObject newPoint = new GameObject("PathPoint_" + pathPoints.Count);
            newPoint.transform.position = pathPoints.Count > 0 ? pathPoints[pathPoints.Count - 1].position : transform.position;
            newPoint.transform.parent = transform;
            pathPoints.Add(newPoint.transform);
        }
        void Update()
        {
            for(int i = 0; i < pathPoints.Count; i++)
            {
                if (pathPoints[i] == null)
                {
                    pathPoints.RemoveAt(i);
                    i--;
                    continue;
                }
                pathPoints[i].gameObject.name = "PathPoint_" + i;
            }
        }
    }
    public int nodeIndex;
    private List<NeighborConnection> neighborConnections = new List<NeighborConnection>();
    public void AddNeighborConnection()
    {
        if (neighborConnections == null)
        {
            neighborConnections = new List<NeighborConnection>();
        }
        NeighborConnection newConnection = new GameObject("Connection_" + nodeIndex + "_" + neighborConnections.Count).AddComponent<NeighborConnection>();
        newConnection.transform.parent = transform;
        neighborConnections.Add(newConnection);
    }
    public void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up * 0.5f, Color.blue);
        for (int c = 0; c < neighborConnections.Count; c++)
        {
            var connection = neighborConnections[c];
            if (connection == null)
            {
                neighborConnections.RemoveAt(c);
                c--;
                continue;
            }
            connection.transform.position = transform.position;
            connection.name = "Connection_" + nodeIndex + "_" + c;
            if (connection.neighborNode == null)
            {
                continue;
            }
            connection.name = "Connection_" + nodeIndex + "_to_" + connection.neighborNode.nodeIndex;
            if (connection.pathPoints != null && connection.pathPoints.Count > 0)
            {
                for (int i = 0; i < connection.pathPoints.Count; i++)
                {
                    if (connection.pathPoints[i] == null)
                    {
                        connection.pathPoints.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < connection.pathPoints.Count - 1; i++)
                {
                    Debug.DrawLine(connection.pathPoints[i].position, connection.pathPoints[i + 1].position, Color.green);
                }
                if (connection.pathPoints.Count > 0)
                {
                    Debug.DrawLine(transform.position, connection.pathPoints[0].position, Color.green);
                    Debug.DrawLine(connection.pathPoints[connection.pathPoints.Count - 1].position, connection.neighborNode.transform.position, Color.green);
                }
                else
                {
                    Debug.DrawLine(transform.position, connection.neighborNode.transform.position, Color.green);
                }
            }
            else
            {
                Debug.DrawLine(transform.position, connection.neighborNode.transform.position, Color.green);
            }
        }
    }
}
