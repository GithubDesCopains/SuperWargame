using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject GrassPrefab;
    public GameObject StonePrefab;

    //public int WidthMap = 5; // X
    //public int HeightMap = 2; // Z

    List<List<Tile>> map = new List<List<Tile>>();

	// Use this for initialization
	void Start () {
        generateMap(new List<List<TileType>> {
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Grass, TileType.Stone },
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Stone, TileType.Stone },
            new List<TileType> { TileType.Grass, TileType.Stone, TileType.Stone, TileType.Grass },
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Stone, TileType.Stone },
        });
	}
    
    // Update is called once per frame
    void Update () {
		
	}

    // Map generation
    private void generateMap(List<List<TileType>> matrice)
    {
        var widthMap = matrice.Count;
        var heightMap = matrice.FirstOrDefault().Count;
        int i = 0, j = 0;

        map = new List<List<Tile>>();

        foreach (var row in matrice)
        {
            List<Tile> rows = new List<Tile>();

            foreach (var tile in row)
            {
                switch (tile)
                {
                    case TileType.Grass:
                        Grass grass = (Instantiate(GrassPrefab, new Vector3(i - Mathf.Floor(widthMap / 2), 0, -j + Mathf.Floor(heightMap / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Grass>();
                        grass.GridPosition = new Vector2(i, j);
                        rows.Add(grass);
                        break;
                    case TileType.Stone:
                        Stone stone = (Instantiate(StonePrefab, new Vector3(i - Mathf.Floor(widthMap / 2), 0, -j + Mathf.Floor(heightMap / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Stone>();
                        stone.GridPosition = new Vector2(i, j);
                        rows.Add(stone);
                        break;
                    default:
                        break;
                }
                j++;
            }
            map.Add(rows);
            j = 0;
            i++;
        }
    }
}
