using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    [SerializeField]
    private Sprite floorSprite; // reference to the floor sprite
    private World world; //reference to the world
	// Use this for initialization
	void Start () {
	    world = new World();
	    for (int x = 0; x < world.Width; x++)
	    {
	        for (int y = 0; y < world.Height; y++)
	        {
                Tile tile_data = world.GetTileAt(x, y); //get the tile data
                GameObject tile_go = new GameObject(); // create a gameobject for each tile
	            tile_go.name = "Tile_" + x + "_" + y; // name the tile
                tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0); //move the game object to its correct position
                tile_go.AddComponent<SpriteRenderer>(); // add an empty sprite renderer
	        }
	    }
	}

    private float randomiseTileTimer = 2f;
	
	// Update is called once per frame
	void Update ()
	{
        Debug.Log("randomised");
	    randomiseTileTimer -= Time.deltaTime;
	    if (randomiseTileTimer < 0)
	    {
	        world.RandomiseTiles();
	        randomiseTileTimer = 2f;
	    }
	}

    void OnTileTypeChanged(Tile tile_data, GameObject tile_go)
    {
        if (tile_data.Type == Tile.TileType.Floor)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (tile_data.Type == Tile.TileType.Empty)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.LogError("OnTileTypeChanged -- Invalid Tile Type");
        }
    }
}
