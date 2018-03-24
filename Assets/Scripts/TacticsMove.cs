using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    Stack<Tile> path = new Stack<Tile>();
    public Tile currentTile;
    public GameObject[] tiles;
    public int move = 5;
    public float jumpHeight = 2.0f;
    public float moveSpeed = 2.0f;
    public float halfHeight = 0.0f;
    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();
    List<Tile> selectableTiles = new List<Tile>();

    public void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        halfHeight = GetComponent<Collider>().bounds.extents.y;
    }

    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.isHadTile = true;
    }

    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;
        Tile tile = null;
        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
            tile = hit.collider.GetComponent<Tile>();
        return tile;
    }

    public void ComputerAdjacencyLists()
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(jumpHeight);
        }
    }

    public void FindSelectableTiles()
    {
        ComputerAdjacencyLists();
        GetCurrentTile();
        Queue<Tile> process = new Queue<Tile>();
        process.Enqueue(currentTile);
        currentTile.isVisited = true;
        while (process.Count > 0)
        {
            Tile t = process.Dequeue();
            selectableTiles.Add(t);
            t.selectable = true;
            if (t.distance < move)
            {
                foreach (Tile tile in t.adjacencyList)
                {
                    if (!tile.isVisited)
                    {
                        tile.parent = t;
                        tile.isVisited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }
}
