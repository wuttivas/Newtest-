using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Menuscript
{
    [MenuItem("Tools/Assign Tile Material")]
    public static void AssignTileMaterial()
    {
        GameObject[] tile = GameObject.FindGameObjectsWithTag("Tile");
        Material material = Resources.Load<Material>("Tile");

        foreach (GameObject t in tile)
        {
            t.GetComponent<Renderer>().material = material;
        }
    }

    [MenuItem("Tools/Assign Tile Script")]
    public static void AssignTileScript()
    {
        GameObject[] tile = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject t in tile)
        {
            t.AddComponent<Tile>();
        }
    }

}
