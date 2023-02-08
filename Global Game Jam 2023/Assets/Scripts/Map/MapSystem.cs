using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    public IDictionary<int, GameObject> MapTiles = new Dictionary<int, GameObject>();
    public IDictionary<int, GameObject> AllBuildings = new Dictionary<int, GameObject>();
    public IDictionary<int, GameObject> EffectTiles = new Dictionary<int, GameObject>();
    [SerializeField] List<Sprite> tileSprites;
    [SerializeField] public int mapX = 20;
    [SerializeField] public int mapY = 20;
    [SerializeField] public int maxHeight = 35;
    public GameObject prefabTile;
    public ResourceManager resourceManager;
    GameObject MapTile;


    [SerializeField] GameObject cursorObject;

    // Start is called before the first frame update
    void Start()
    {
        int id = 0;
        for (int x = 0; x < mapX; x++)
        {
            for (int y = 0; y < mapY/2; y++)
            {
                int typeSelector = Random.Range(0, 3);

                MapTile = Instantiate(prefabTile, new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);


                MapTiles.Add(id, transform.GetChild(id).gameObject);
                AllBuildings.Add(id, transform.GetChild(id).gameObject);
                MapTiles[id].GetComponent<GameTile>().TileType = typeSelector;
                MapTiles[id].GetComponent<GameTile>().cursor = cursorObject;
                MapTiles[id].GetComponent<SpriteRenderer>().sprite = tileSprites[typeSelector];
                MapTiles[id].name = $"MapX{x}Y{y}";
                id++;
            }
            for (int y = mapY/2; y < mapY; y++)
            {

                MapTile = Instantiate(prefabTile, new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);


                MapTiles.Add(id, transform.GetChild(id).gameObject);
                AllBuildings.Add(id, transform.GetChild(id).gameObject);
                MapTiles[id].GetComponent<GameTile>().TileType = 3;
                MapTiles[id].GetComponent<GameTile>().cursor = cursorObject;
                MapTiles[id].GetComponent<SpriteRenderer>().sprite = tileSprites[3];
                MapTiles[id].name = $"SkyX{x}Y{y}";
                id++;
            }
        }

        

    }

}
