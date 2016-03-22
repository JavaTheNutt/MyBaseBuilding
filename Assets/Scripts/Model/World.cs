using UnityEngine;
using System.Collections;
/**
*This will hold an array of tiles and perform all operations on this array of tiles
*/
public class World
{
    Tile[,] tiles;
    int width;
    int height;

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }

    

    public World(int width = 100, int height = 100)
    {
        this.width = width;
        this.height = height;
        tiles = new Tile[width,height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(this, x, y);
            }
        }
        Debug.Log("World created with " + (width * height) + " tiles");
    }

    public void RandomiseTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    tiles[x, y].Type = TileType.Empty;
                }
                else
                {
                    tiles[x, y].Type = TileType.Floor;
                }
            }
        }
    }
    public Tile GetTileAt(int x ,int y )
    {
        if (x > width || y > height || x < 0 || y < 0)
        {
            //Debug.Log("Tile (" + x + "," + y + ") is out of bounds" );
            return null;
        }
        return tiles[x, y];
    }
}
