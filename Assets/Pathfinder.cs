using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    
    void Start()
    {
        LoadBlocks();
    }
    
    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverLapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverLapping)
            {
                Debug.LogWarning("Skipping overlapping block: " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
