using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileDescription : MonoBehaviour
{
    [SerializeField] MapSystem map;
    [SerializeField] Text TileTypeTxt;
    [SerializeField] Text PositionTxt;
    [SerializeField] Text ResourcesTxt;


    public bool onUpdate = false;
    int x, y;
    GameTile tempTile;
    public int id;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onUpdate == true)
        {
            y = Mathf.RoundToInt(transform.position.x);
            x = Mathf.RoundToInt(transform.position.y);
            id = (y * map.mapY) + x;
            tempTile = map.MapTiles[id].GetComponent<GameTile>();
            TileTypeTxt.text = tempTile.tileName;
            ResourcesTxt.text = "Resources: "+ map.MapTiles[id].GetComponent<GameTile>().resources[0].amount + " " + map.MapTiles[id].GetComponent<GameTile>().resources[0].resourceName;
            if (map.MapTiles[id].GetComponent<GameTile>().resources[0].amount == 0 || map.MapTiles[id].GetComponent<GameTile>().resources[0].resourceName == "None")
            {
                ResourcesTxt.text = "Resources: None";
            }
            else
            {
                ResourcesTxt.text = "Resources: " + map.MapTiles[id].GetComponent<GameTile>().resources[0].amount + " " + map.MapTiles[id].GetComponent<GameTile>().resources[0].resourceName;
            }

            PositionTxt.text = $"Position: {x}, {y}";
        }
    }
}
