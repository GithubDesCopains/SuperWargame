using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject TilePrefab;

    //public int WidthMap = 5; // X
    //public int HeightMap = 2; // Z

    List<List<Tile>> map = new List<List<Tile>>();

	// Use this for initialization
	void Start () {
        generateMap(new List<List<TileType>> {
            new List<TileType> { TileType.Stone, TileType.Grass, TileType.Grass, TileType.Stone },
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Stone, TileType.Grass },
            new List<TileType> { TileType.Grass, TileType.Stone, TileType.Grass, TileType.Grass }
        });
	}
    
    // Update is called once per frame
    void Update () {
		
	}

    // Map generation
    private void generateMap(List<List<TileType>> matrice)
    {
        var widthMap = matrice.FirstOrDefault().Count;
        var heightMap = matrice.Count;

        map = new List<List<Tile>>();

        foreach (var row in matrice)
        {
            int i = 0;
            List<Tile> rows = new List<Tile>();

            foreach (var tile in row)
            {
                int j = 0;
                switch (tile)
                {
                    case TileType.Grass:
                        Grass grass = (Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(widthMap / 2), 0, -j + Mathf.Floor(heightMap / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Grass>();
                        grass.GridPosition = new Vector2(i, j);
                        rows.Add(grass);
                        break;
                    case TileType.Stone:
                        Stone stone = (Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(widthMap / 2), 0, -j + Mathf.Floor(heightMap / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Stone>();
                        stone.GridPosition = new Vector2(i, j);
                        rows.Add(stone);
                        break;
                    default:
                        break;
                }
                j++;
            }
            map.Add(rows);
            i++;
        }
    }
}
