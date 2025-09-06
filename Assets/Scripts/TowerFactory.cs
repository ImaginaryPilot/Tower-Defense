using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int TowerLimit = 3;
    [SerializeField] Tower SpawnTower;
    [SerializeField] Transform Towerparent;

    Queue<Tower> towerLimit = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerLimit.Count;
        if (numTowers < TowerLimit)
        {
            var NewTower = Instantiate(SpawnTower, baseWaypoint.transform.position, Quaternion.identity);
            NewTower.transform.parent = Towerparent;
            baseWaypoint.isPlaceable = false;

            NewTower.baseWaypoint = baseWaypoint;
            baseWaypoint.isPlaceable = false;

            towerLimit.Enqueue(NewTower);
        }
        else
        {
            var oldTower = towerLimit.Dequeue();

            oldTower.baseWaypoint.isPlaceable = true;
            baseWaypoint.isPlaceable = false;

            oldTower.baseWaypoint = baseWaypoint;
            oldTower.transform.position = baseWaypoint.transform.position;

            towerLimit.Enqueue(oldTower);
        }
    }
}
