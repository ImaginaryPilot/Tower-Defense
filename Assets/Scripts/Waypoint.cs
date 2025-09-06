using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    Vector2Int gridPos;
    const int gridsize = 10;

    public int GetGridSize()
    {
        return gridsize;
    }
    
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridsize),
            Mathf.RoundToInt(transform.position.z / gridsize)
        );
    }
    
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType < TowerFactory >() .AddTower(this);
            }
            else
            {
                Debug.Log("You can't place over here");
            }
        }
    }
}
