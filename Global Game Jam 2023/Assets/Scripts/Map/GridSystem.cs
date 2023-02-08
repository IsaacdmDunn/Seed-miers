using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] int mapX;
    [SerializeField] int mapY;
    public GameObject prefabTile;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < mapX; x++)
        {
            for (int y = 0; y < mapY; x++)
            {
                //int typeSelector = Random.RandomRange(0, 1);


                //prefabTile.GetComponent<GameTile>().TileType = typeSelector;
                //prefabTile.GetComponent<SpriteRenderer>().sprite = tileSprites[typeSelector];

                Instantiate(prefabTile, new Vector3(mapX, mapY, 0), Quaternion.identity, gameObject.transform);




            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
