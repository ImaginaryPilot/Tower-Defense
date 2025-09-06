using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint seacrhCenter;
    List<Waypoint> path = new List<Waypoint>();


    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceable = false;
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        startWaypoint.isPlaceable = false;
        path.Reverse();
    }

    void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            seacrhCenter = queue.Dequeue();
            if (seacrhCenter == endWaypoint)
            {
                isRunning = false;
            }
            ExploreNeighbours();
            seacrhCenter.isExplored = true;

        }

    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explors = seacrhCenter.GetGridPos() + direction;
            if (grid.ContainsKey(explors))
            {
                Waypoint neighbour = grid[explors];
                if (neighbour.isExplored || queue.Contains(neighbour))
                {
                    //do nothing
                }
                else
                {
                    queue.Enqueue(neighbour);
                    neighbour.exploredFrom = seacrhCenter;
                }
            }
        }
    }


    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool IsOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (IsOverlapping)
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
