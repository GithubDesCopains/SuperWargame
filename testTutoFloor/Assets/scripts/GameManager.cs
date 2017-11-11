using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject GrassPrefab;
    public GameObject StonePrefab;

    List<List<Tile>> map = new List<List<Tile>>();

	// Use this for initialization
	void Start () {
        var toto = new List<List<TileType>> {
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass },
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Stone, TileType.Stone, TileType.Stone, TileType.Stone, TileType.Stone, TileType.Grass, TileType.Grass },
            new List<TileType> { TileType.Grass, TileType.Stone, TileType.Stone, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Stone, TileType.Grass, TileType.Grass },
            new List<TileType> { TileType.Stone, TileType.Stone, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Stone, TileType.Stone, TileType.Stone },
            new List<TileType> { TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass, TileType.Grass }
        };
        generateMap(toto);
	}
    
    // Update is called once per frame
    void Update () {
		
	}
    
    /// <summary>
    /// Map generation
    /// </summary>
    /// <param name="matrice"></param>
    private void generateMap(List<List<TileType>> matrice)
    {
        var widthMap = matrice.FirstOrDefault().Count ;
        var heightMap = matrice.Count;
        //int i = 0, j = 0;

        map = new List<List<Tile>>();

        for (int i = 0; i < widthMap; i++)
        {
            List<Tile> rows = new List<Tile>();
            for (int j = 0; j < heightMap; j++)
            {
                GameObject prefab = GetTypePrefab(matrice.ElementAt(j).ElementAt(i));

                Tile tile = (Instantiate(prefab, new Vector3(i - Mathf.Floor(widthMap / 2), 0, -j + Mathf.Floor(heightMap / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.GridPosition = new Vector2(i, j);
                rows.Add(tile);
            }
            map.Add(rows);
        }

        /** Probleme parcour de la matrice en heigth / width resultat pivoter de -90 sur Y **/

        //foreach (var row in matrice)
        //{
        //    List<Tile> rows = new List<Tile>();

        //    foreach (var tileType in row)
        //    {
        //        GameObject prefab = GetTypePrefab(tileType);

        //        Tile tile = (Instantiate(prefab, new Vector3(i - Mathf.Floor(widthMap / 2), 0, -j + Mathf.Floor(heightMap / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
        //        tile.GridPosition = new Vector2(i, j);
        //        rows.Add(tile);
        //        ++j;
        //    }
        //    map.Add(rows);
        //    j = 0;
        //    ++i;
        //}
    }

    /// <summary>
    /// Select type of prefab to instanciate it
    /// </summary>
    /// <param name="tileType"></param>
    /// <returns></returns>
    private GameObject GetTypePrefab(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Grass:
                return GrassPrefab;
            case TileType.Stone:
                return StonePrefab;
            default:
                throw new NotImplementedException();
        }
    }
}
