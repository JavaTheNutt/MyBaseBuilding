using UnityEngine;
using System.Collections;
/**
*This will represent an instance of an installed object such as a wall or door
*/
public class InstalledObject
{
    public Tile Tile { get; protected set; }
    public string ObjectType { get; protected set; }
    public float MovementCost { get; protected set; }

    public int Width { get; protected set; }
    public int Height { get; protected set; }

    public InstalledObject(string objectType, float movementCost = 1f, int width = 1, int height = 1)
    {
        ObjectType = objectType;
        MovementCost = movementCost;
        Width = width;
        Height = height;
    }
    public InstalledObject(Tile tile, InstalledObject proto)
    {
        Tile = tile;
        ObjectType = proto.ObjectType;
        MovementCost = proto.MovementCost;
        Width = proto.Width;
        Height = proto.Height;
    }
    
}
