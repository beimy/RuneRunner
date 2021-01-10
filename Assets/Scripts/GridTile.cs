using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public enum TileStatus { Open, Occupied, Raised };
    public TileStatus myTileStatus;
  
    public class Tile
    {
        [SerializeField]
        enum TileStatus { Open, Occupied, Raised };
        GameObject OccupyingObject;

    }

    private void Start()
    {
        myTileStatus = TileStatus.Open;
    }

    public void OccupyTile()
    {
        myTileStatus = TileStatus.Occupied;
    }
}
