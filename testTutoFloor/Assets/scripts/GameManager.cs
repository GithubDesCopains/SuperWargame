using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject TilePrefab;

    public int WidthMap = 5; // X
    public int HeightMap = 2; // Z

    List<List<Tile>> map = new List<List<Tile>>();

	// Use this for initialization
	void Start () {
        generateMap();
	}
    
    // Update is called once per frame
    void Update () {
		
	}

    // Map generation
    private void generateMap()
    {
        map = new List<List<Tile>>();

        for (int i = 0; i < WidthMap; i++)
        {
            List<Tile> row = new List<Tile>();
            for (int j = 0; j < HeightMap; j++)
            {
                Tile tile = (Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(WidthMap/2),0, -j + Mathf.Floor(HeightMap/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.GridPosition = new Vector2(i, j);
                row.Add(tile);
            }
            map.Add(row);
        }
    }
}
