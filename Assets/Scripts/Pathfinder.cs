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

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,        
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        // ExploreNeighbours();
    }

    private void Pathfind() 
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0) {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching from: " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }
        
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (startWaypoint == endWaypoint) {
            print("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from) 
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = from.GetGridPos() + direction;
            print("Exploring " + neighbourCoords);

            try
            {
                QueueNewNeighbours(neighbourCoords);
            }
            catch { }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoords)
    {
        Waypoint neighbour = grid[neighbourCoords];
        if (neighbour.isExplored) {
            // do nothing
        } else {
            neighbour.SetTopColor(Color.blue); // todo remove later
            queue.Enqueue(neighbour);
            print("Queueing: " + neighbour);
        }
    }

    private void ColorStartAndEnd() 
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Overlapping block: " + waypoint);
            } else {
                grid.Add(gridPos, waypoint);
            }
        }
        print("Loaded: " + grid.Count + " blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
