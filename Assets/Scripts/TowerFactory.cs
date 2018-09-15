using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towersParent;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    void InstantiateTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towersParent);
        baseWaypoint.isPlacable = false;
        newTower.baseWaypoint = baseWaypoint;
        towers.Enqueue(newTower);
    }

    void MoveExistingTower(Waypoint baseWaypoint)
    {
        var oldTower = towers.Dequeue();
        oldTower.transform.position = baseWaypoint.transform.position;
        oldTower.baseWaypoint.isPlacable = true;
        oldTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlacable = false;
        towers.Enqueue(oldTower);
    }
}
