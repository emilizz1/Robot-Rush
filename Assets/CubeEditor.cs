using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent (typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    int gridSize;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update ()
    {
        gridSize = waypoint.GetGridSize();
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x / gridSize + "." + waypoint.GetGridPos().y / gridSize ;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
