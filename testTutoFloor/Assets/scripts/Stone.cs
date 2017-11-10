using UnityEngine;
using System.Collections;

public class Stone : Tile
{
    private Vector2 gridPosition;
    public override Vector2 GridPosition
    {
        get
        {
            return gridPosition;
        }

        set
        {
            gridPosition = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
