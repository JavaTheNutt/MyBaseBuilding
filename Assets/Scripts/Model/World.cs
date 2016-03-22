using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/**
*This will hold an array of tiles and perform all operations on this array of tiles
*/
public class World
{
    private Tile[,] tiles;

    public int Width { get; protected set; }

    public int Height { get; protected set; }

    private Dictionary<string, InstalledObject> installedObjectPrototypes;

    public World(int width = 100, int height = 100)
    {
        this.Width = width;
        this.Height = height;
        tiles = new Tile[width,height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(this, x, y);
            }
        }
        installedObjectPrototypes = new Dictionary<string, InstalledObject>();
        CreateInstalledObjectPrototypes();
        Debug.Log("World created with " + (width * height) + " tiles");
    }

    private void CreateInstalledObjectPrototypes()
    {
        installedObjectPrototypes.Add("Wall", InstalledObject.CreatePrototype("Wall", 0f, 1, 1));
    }
    
    public Tile GetTileAt(int x ,int y )
    {
        if (x > Width || y > Height || x < 0 || y < 0)
        {
            //Debug.Log("Tile (" + x + "," + y + ") is out of bounds" );
            return null;
        }
        return tiles[x, y];
    }
}
